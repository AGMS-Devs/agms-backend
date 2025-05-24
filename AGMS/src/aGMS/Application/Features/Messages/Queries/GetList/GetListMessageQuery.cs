using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Messages.Queries.GetList;

public class GetListMessageQuery : IRequest<GetListResponse<GetListMessageListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListMessageQueryHandler : IRequestHandler<GetListMessageQuery, GetListResponse<GetListMessageListItemDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetListMessageQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMessageListItemDto>> Handle(GetListMessageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Message> messages = await _messageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMessageListItemDto> response = _mapper.Map<GetListResponse<GetListMessageListItemDto>>(messages);
            return response;
        }
    }
}