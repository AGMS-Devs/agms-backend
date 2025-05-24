using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.FacultyDeansOffices.Queries.GetList;

public class GetListFacultyDeansOfficeQuery : IRequest<GetListResponse<GetListFacultyDeansOfficeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListFacultyDeansOfficeQueryHandler : IRequestHandler<GetListFacultyDeansOfficeQuery, GetListResponse<GetListFacultyDeansOfficeListItemDto>>
    {
        private readonly IFacultyDeansOfficeRepository _facultyDeansOfficeRepository;
        private readonly IMapper _mapper;

        public GetListFacultyDeansOfficeQueryHandler(IFacultyDeansOfficeRepository facultyDeansOfficeRepository, IMapper mapper)
        {
            _facultyDeansOfficeRepository = facultyDeansOfficeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFacultyDeansOfficeListItemDto>> Handle(GetListFacultyDeansOfficeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<FacultyDeansOffice> facultyDeansOffices = await _facultyDeansOfficeRepository.GetListAsync(
                include: fdo => fdo.Include(x => x.Departments),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFacultyDeansOfficeListItemDto> response = _mapper.Map<GetListResponse<GetListFacultyDeansOfficeListItemDto>>(facultyDeansOffices);
            return response;
        }
    }
}