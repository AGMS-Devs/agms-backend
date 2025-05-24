using Application.Features.FacultyDeansOffices.Constants;
using Application.Features.FacultyDeansOffices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FacultyDeansOffices.Commands.Delete;

public class DeleteFacultyDeansOfficeCommand : IRequest<DeletedFacultyDeansOfficeResponse>
{
    public Guid Id { get; set; }

    public class DeleteFacultyDeansOfficeCommandHandler : IRequestHandler<DeleteFacultyDeansOfficeCommand, DeletedFacultyDeansOfficeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFacultyDeansOfficeRepository _facultyDeansOfficeRepository;
        private readonly FacultyDeansOfficeBusinessRules _facultyDeansOfficeBusinessRules;

        public DeleteFacultyDeansOfficeCommandHandler(IMapper mapper, IFacultyDeansOfficeRepository facultyDeansOfficeRepository,
                                         FacultyDeansOfficeBusinessRules facultyDeansOfficeBusinessRules)
        {
            _mapper = mapper;
            _facultyDeansOfficeRepository = facultyDeansOfficeRepository;
            _facultyDeansOfficeBusinessRules = facultyDeansOfficeBusinessRules;
        }

        public async Task<DeletedFacultyDeansOfficeResponse> Handle(DeleteFacultyDeansOfficeCommand request, CancellationToken cancellationToken)
        {
            FacultyDeansOffice? facultyDeansOffice = await _facultyDeansOfficeRepository.GetAsync(predicate: fdo => fdo.Id == request.Id, cancellationToken: cancellationToken);
            await _facultyDeansOfficeBusinessRules.FacultyDeansOfficeShouldExistWhenSelected(facultyDeansOffice);

            await _facultyDeansOfficeRepository.DeleteAsync(facultyDeansOffice!);

            DeletedFacultyDeansOfficeResponse response = _mapper.Map<DeletedFacultyDeansOfficeResponse>(facultyDeansOffice);
            return response;
        }
    }
}