using Application.Features.FacultyDeansOffices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FacultyDeansOffices.Commands.Create;

public class CreateFacultyDeansOfficeCommand : IRequest<CreatedFacultyDeansOfficeResponse>
{
    public string FacultyName { get; set; }
    public Guid StudentAffairId { get; set; }
    public StudentAffair StudentAffair { get; set; }

    public class CreateFacultyDeansOfficeCommandHandler : IRequestHandler<CreateFacultyDeansOfficeCommand, CreatedFacultyDeansOfficeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFacultyDeansOfficeRepository _facultyDeansOfficeRepository;
        private readonly FacultyDeansOfficeBusinessRules _facultyDeansOfficeBusinessRules;

        public CreateFacultyDeansOfficeCommandHandler(IMapper mapper, IFacultyDeansOfficeRepository facultyDeansOfficeRepository,
                                         FacultyDeansOfficeBusinessRules facultyDeansOfficeBusinessRules)
        {
            _mapper = mapper;
            _facultyDeansOfficeRepository = facultyDeansOfficeRepository;
            _facultyDeansOfficeBusinessRules = facultyDeansOfficeBusinessRules;
        }

        public async Task<CreatedFacultyDeansOfficeResponse> Handle(CreateFacultyDeansOfficeCommand request, CancellationToken cancellationToken)
        {
            FacultyDeansOffice facultyDeansOffice = _mapper.Map<FacultyDeansOffice>(request);

            await _facultyDeansOfficeRepository.AddAsync(facultyDeansOffice);

            CreatedFacultyDeansOfficeResponse response = _mapper.Map<CreatedFacultyDeansOfficeResponse>(facultyDeansOffice);
            return response;
        }
    }
}