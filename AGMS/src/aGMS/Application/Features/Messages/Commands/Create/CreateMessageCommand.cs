using Application.Features.Messages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.Features.Messages.Commands.Create;

public class CreateMessageCommand : IRequest<CreatedMessageResponse>
{
    public string Content { get; set; }
    public Guid ReceiverId { get; set; }

    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, CreatedMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MessageBusinessRules _messageBusinessRules;

        public CreateMessageCommandHandler(IMapper mapper, IMessageRepository messageRepository, 
                                         IUserRepository userRepository, IHttpContextAccessor httpContextAccessor,
                                         MessageBusinessRules messageBusinessRules)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _messageBusinessRules = messageBusinessRules;
        }

        public async Task<CreatedMessageResponse> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            // Current user'ın ID'sini al
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out Guid senderId))
            {
                throw new UnauthorizedAccessException("User not authenticated or invalid user ID");
            }

            // Receiver kontrolü
            User? receiver = await _userRepository.GetAsync(
                predicate: u => u.Id == request.ReceiverId,
                cancellationToken: cancellationToken
            );
            
            if (receiver == null)
                throw new Exception("Receiver user not found");

            // Sender kontrolü (opsiyonel - emin olmak için)
            User? sender = await _userRepository.GetAsync(
                predicate: u => u.Id == senderId,
                cancellationToken: cancellationToken
            );
            
            if (sender == null)
                throw new Exception("Sender user not found");

            // Message oluştur - SenderId current user'ın ID'si
            Message message = new Message(
                content: request.Content,
                senderId: senderId,
                receiverId: request.ReceiverId
            );

            await _messageRepository.AddAsync(message);

            // Response için gerekli User bilgilerini yükle
            Message messageWithUsers = await _messageRepository.GetAsync(
                predicate: m => m.Id == message.Id,
                include: query => query.Include(m => m.Sender).Include(m => m.Receiver),
                cancellationToken: cancellationToken
            );

            CreatedMessageResponse response = _mapper.Map<CreatedMessageResponse>(messageWithUsers);
            return response;
        }
    }
}