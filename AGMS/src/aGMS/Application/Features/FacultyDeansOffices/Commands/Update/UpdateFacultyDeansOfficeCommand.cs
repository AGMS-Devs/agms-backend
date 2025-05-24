using Application.Features.FacultyDeansOffices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FacultyDeansOffices.Commands.Update;

public class UpdateFacultyDeansOfficeCommand : IRequest<UpdatedFacultyDeansOfficeResponse>
{
    public Guid Id { get; set; }
    public string FacultyName { get; set; }
    public Guid StudentAffairId { get; set; }
    public StudentAffair StudentAffair { get; set; }

    public class UpdateFacultyDeansOfficeCommandHandler : IRequestHandler<UpdateFacultyDeansOfficeCommand, UpdatedFacultyDeansOfficeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFacultyDeansOfficeRepository _facultyDeansOfficeRepository;
        private readonly FacultyDeansOfficeBusinessRules _facultyDeansOfficeBusinessRules;

        public UpdateFacultyDeansOfficeCommandHandler(IMapper mapper, IFacultyDeansOfficeRepository facultyDeansOfficeRepository,
                                         FacultyDeansOfficeBusinessRules facultyDeansOfficeBusinessRules)
        {
            _mapper = mapper;
            _facultyDeansOfficeRepository = facultyDeansOfficeRepository;
            _facultyDeansOfficeBusinessRules = facultyDeansOfficeBusinessRules;
        }

        public async Task<UpdatedFacultyDeansOfficeResponse> Handle(UpdateFacultyDeansOfficeCommand request, CancellationToken cancellationToken)
        {
            FacultyDeansOffice? facultyDeansOffice = await _facultyDeansOfficeRepository.GetAsync(predicate: fdo => fdo.Id == request.Id, cancellationToken: cancellationToken);
            await _facultyDeansOfficeBusinessRules.FacultyDeansOfficeShouldExistWhenSelected(facultyDeansOffice);
            facultyDeansOffice = _mapper.Map(request, facultyDeansOffice);

            await _facultyDeansOfficeRepository.UpdateAsync(facultyDeansOffice!);

            UpdatedFacultyDeansOfficeResponse response = _mapper.Map<UpdatedFacultyDeansOfficeResponse>(facultyDeansOffice);
            return response;
        }
    }
}