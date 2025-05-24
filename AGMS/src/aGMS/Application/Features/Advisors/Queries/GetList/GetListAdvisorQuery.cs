using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Advisors.Queries.GetList;

public class GetListAdvisorQuery : IRequest<GetListResponse<GetListAdvisorListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAdvisorQueryHandler : IRequestHandler<GetListAdvisorQuery, GetListResponse<GetListAdvisorListItemDto>>
    {
        private readonly IAdvisorRepository _advisorRepository;
        private readonly IMapper _mapper;

        public GetListAdvisorQueryHandler(IAdvisorRepository advisorRepository, IMapper mapper)
        {
            _advisorRepository = advisorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAdvisorListItemDto>> Handle(GetListAdvisorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Advisor> advisors = await _advisorRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: query => query
                    .Include(a => a.User)
                    .Include(a => a.Department),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAdvisorListItemDto> response = _mapper.Map<GetListResponse<GetListAdvisorListItemDto>>(advisors);

            foreach (var item in response.Items)
            {
                var advisor = advisors.Items.First(a => a.Id == item.Id);
                if (advisor.User != null)
                {
                    item.Name = advisor.User.Name;
                    item.Surname = advisor.User.Surname;
                }
                if (advisor.Department != null)
                {
                    item.DepartmentName = advisor.Department.DepartmentName;
                }
            }

            return response;
        }
    }
}