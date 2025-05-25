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
    public string? StudentNumber { get; set; } // Öğrenci numarası ile filtreleme

    public class GetListMessageQueryHandler : IRequestHandler<GetListMessageQuery, GetListResponse<GetListMessageListItemDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAdvisorRepository _advisorRepository;

        public GetListMessageQueryHandler(IMessageRepository messageRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAdvisorRepository advisorRepository)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _advisorRepository = advisorRepository;
        }

        public async Task<GetListResponse<GetListMessageListItemDto>> Handle(GetListMessageQuery request, CancellationToken cancellationToken)
        {
            // Current user'ın ID'sini al
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out Guid currentUserId))
            {
                throw new UnauthorizedAccessException("User not authenticated or invalid user ID");
            }

            Expression<Func<Message, bool>> predicate;

            // Current user'ın Advisor olup olmadığını kontrol et
            var advisor = await _advisorRepository.GetAsync(
                predicate: a => a.Id == currentUserId,
                cancellationToken: cancellationToken
            );

            if (advisor != null)
            {
                // Advisor ise: kendi gönderdiği mesajları görür
                if (!string.IsNullOrEmpty(request.StudentNumber))
                {
                    // Belirli bir öğrenciye gönderilen mesajlar
                    predicate = m => m.AdvisorId == currentUserId && m.StudentNumber == request.StudentNumber;
                }
                else
                {
                    // Tüm gönderdiği mesajlar
                    predicate = m => m.AdvisorId == currentUserId;
                }
            }
            else
            {
                // Student ise: kendisine gönderilen mesajları görür
                // Öğrenci numarasını user'dan almamız gerekiyor
                // Şimdilik exception fırlatalım - bu kısmı User-Student ilişkisine göre düzenleyeceğiz
                throw new UnauthorizedAccessException("Student access requires student number identification");
            }

            IPaginate<Message> messages = await _messageRepository.GetListAsync(
                predicate: predicate,
                orderBy: query => query.OrderByDescending(m => m.SentAt),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: query => query.Include(m => m.Advisor),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMessageListItemDto> response = _mapper.Map<GetListResponse<GetListMessageListItemDto>>(messages);
            return response;
        }
    }
}