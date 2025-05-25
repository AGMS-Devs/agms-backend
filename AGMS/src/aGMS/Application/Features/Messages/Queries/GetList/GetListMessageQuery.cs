using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Linq.Expressions;

namespace Application.Features.Messages.Queries.GetList;

public class GetListMessageQuery : IRequest<GetListResponse<GetListMessageListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public bool OnlyReceived { get; set; } = true; // Default: Sadece alınan mesajları göster

    public class GetListMessageQueryHandler : IRequestHandler<GetListMessageQuery, GetListResponse<GetListMessageListItemDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetListMessageQueryHandler(IMessageRepository messageRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetListResponse<GetListMessageListItemDto>> Handle(GetListMessageQuery request, CancellationToken cancellationToken)
        {
            // Current user'ın ID'sini al
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out Guid currentUserId))
            {
                throw new UnauthorizedAccessException("User not authenticated or invalid user ID");
            }

            // Filtreleme: Sadece alınan mesajlar veya hem alınan hem gönderilen
            Expression<Func<Message, bool>> predicate = request.OnlyReceived 
                ? m => m.ReceiverId == currentUserId
                : m => m.ReceiverId == currentUserId || m.SenderId == currentUserId;

            IPaginate<Message> messages = await _messageRepository.GetListAsync(
                predicate: predicate,
                orderBy: query => query.OrderByDescending(m => m.SentAt),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: query => query.Include(m => m.Sender).Include(m => m.Receiver),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMessageListItemDto> response = _mapper.Map<GetListResponse<GetListMessageListItemDto>>(messages);
            return response;
        }
    }
}