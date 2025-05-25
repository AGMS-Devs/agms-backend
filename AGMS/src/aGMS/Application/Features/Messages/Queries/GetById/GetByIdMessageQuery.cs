using Application.Features.Messages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.Features.Messages.Queries.GetById;

public class GetByIdMessageQuery : IRequest<GetByIdMessageResponse>
{
    public Guid Id { get; set; }

    public class GetByIdMessageQueryHandler : IRequestHandler<GetByIdMessageQuery, GetByIdMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly MessageBusinessRules _messageBusinessRules;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetByIdMessageQueryHandler(IMapper mapper, IMessageRepository messageRepository, 
                                        MessageBusinessRules messageBusinessRules, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _messageBusinessRules = messageBusinessRules;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetByIdMessageResponse> Handle(GetByIdMessageQuery request, CancellationToken cancellationToken)
        {
            // Current user'ın ID'sini al
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out Guid currentUserId))
            {
                throw new UnauthorizedAccessException("User not authenticated or invalid user ID");
            }

            // Sadece current user'a gönderilen ve belirtilen ID'ye sahip mesajı getir
            Message? message = await _messageRepository.GetAsync(
                predicate: m => m.Id == request.Id && m.ReceiverId == currentUserId,
                include: query => query.Include(m => m.Sender).Include(m => m.Receiver),
                cancellationToken: cancellationToken);
                
            await _messageBusinessRules.MessageShouldExistWhenSelected(message);

            GetByIdMessageResponse response = _mapper.Map<GetByIdMessageResponse>(message);
            return response;
        }
    }
}