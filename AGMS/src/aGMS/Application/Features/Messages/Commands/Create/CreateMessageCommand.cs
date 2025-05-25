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
    public string StudentNumber { get; set; }

    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, CreatedMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly IAdvisorRepository _advisorRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MessageBusinessRules _messageBusinessRules;

        public CreateMessageCommandHandler(IMapper mapper, IMessageRepository messageRepository, 
                                         IAdvisorRepository advisorRepository, IHttpContextAccessor httpContextAccessor,
                                         MessageBusinessRules messageBusinessRules)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _advisorRepository = advisorRepository;
            _httpContextAccessor = httpContextAccessor;
            _messageBusinessRules = messageBusinessRules;
        }

        public async Task<CreatedMessageResponse> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            // Current user'ın ID'sini al
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out Guid currentUserId))
            {
                throw new UnauthorizedAccessException("User not authenticated or invalid user ID");
            }

            // Current user'ın Advisor olup olmadığını kontrol et
            Advisor? advisor = await _advisorRepository.GetAsync(
                predicate: a => a.Id == currentUserId,
                cancellationToken: cancellationToken
            );
            
            if (advisor == null)
                throw new UnauthorizedAccessException("Only advisors can send messages");

            // StudentNumber validation (öğrenci numarasının geçerli olup olmadığını kontrol edebiliriz)
            if (string.IsNullOrWhiteSpace(request.StudentNumber))
                throw new ArgumentException("Student number cannot be empty");

            // Message oluştur - AdvisorId current user'ın ID'si
            Message message = new Message(
                content: request.Content,
                advisorId: currentUserId,
                studentNumber: request.StudentNumber
            );

            await _messageRepository.AddAsync(message);

            // Response için gerekli Advisor bilgilerini yükle
            Message messageWithAdvisor = await _messageRepository.GetAsync(
                predicate: m => m.Id == message.Id,
                include: query => query.Include(m => m.Advisor),
                cancellationToken: cancellationToken
            );

            CreatedMessageResponse response = _mapper.Map<CreatedMessageResponse>(messageWithAdvisor);
            return response;
        }
    }
}