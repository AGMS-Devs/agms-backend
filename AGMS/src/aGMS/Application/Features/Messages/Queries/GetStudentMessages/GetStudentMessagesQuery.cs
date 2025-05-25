using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Messages.Queries.GetStudentMessages;

public class GetStudentMessagesQuery : IRequest<GetListResponse<GetStudentMessagesListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public string StudentNumber { get; set; }

    public class GetStudentMessagesQueryHandler : IRequestHandler<GetStudentMessagesQuery, GetListResponse<GetStudentMessagesListItemDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetStudentMessagesQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetStudentMessagesListItemDto>> Handle(GetStudentMessagesQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.StudentNumber))
            {
                throw new ArgumentException("Student number is required");
            }

            IPaginate<Message> messages = await _messageRepository.GetListAsync(
                predicate: m => m.StudentNumber == request.StudentNumber,
                orderBy: query => query.OrderByDescending(m => m.SentAt),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: query => query.Include(m => m.Advisor),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetStudentMessagesListItemDto> response = _mapper.Map<GetListResponse<GetStudentMessagesListItemDto>>(messages);
            return response;
        }
    }
}