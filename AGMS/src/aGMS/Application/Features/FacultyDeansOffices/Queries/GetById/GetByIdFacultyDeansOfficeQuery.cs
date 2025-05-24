using Application.Features.FacultyDeansOffices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.FacultyDeansOffices.Queries.GetById;

public class GetByIdFacultyDeansOfficeQuery : IRequest<GetByIdFacultyDeansOfficeResponse>
{
    public Guid Id { get; set; }

    public class GetByIdFacultyDeansOfficeQueryHandler : IRequestHandler<GetByIdFacultyDeansOfficeQuery, GetByIdFacultyDeansOfficeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFacultyDeansOfficeRepository _facultyDeansOfficeRepository;
        private readonly FacultyDeansOfficeBusinessRules _facultyDeansOfficeBusinessRules;

        public GetByIdFacultyDeansOfficeQueryHandler(IMapper mapper, IFacultyDeansOfficeRepository facultyDeansOfficeRepository, FacultyDeansOfficeBusinessRules facultyDeansOfficeBusinessRules)
        {
            _mapper = mapper;
            _facultyDeansOfficeRepository = facultyDeansOfficeRepository;
            _facultyDeansOfficeBusinessRules = facultyDeansOfficeBusinessRules;
        }

        public async Task<GetByIdFacultyDeansOfficeResponse> Handle(GetByIdFacultyDeansOfficeQuery request, CancellationToken cancellationToken)
        {
            FacultyDeansOffice? facultyDeansOffice = await _facultyDeansOfficeRepository.GetAsync(
                predicate: fdo => fdo.Id == request.Id,
                include: fdo => fdo.Include(x => x.Departments),
                cancellationToken: cancellationToken
            );
            await _facultyDeansOfficeBusinessRules.FacultyDeansOfficeShouldExistWhenSelected(facultyDeansOffice);

            GetByIdFacultyDeansOfficeResponse response = _mapper.Map<GetByIdFacultyDeansOfficeResponse>(facultyDeansOffice);
            return response;
        }
    }
}