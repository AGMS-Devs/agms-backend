using Application.Features.Staffs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;
namespace Application.Features.Staffs.Commands.Update;

public class UpdateStaffCommand : IRequest<UpdatedStaffResponse>
{
    public Guid Id { get; set; }
    public string StaffPhone { get; set; }
    public StaffRole StaffRole { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? FacultyId { get; set; }

    public class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffCommand, UpdatedStaffResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStaffRepository _staffRepository;
        private readonly StaffBusinessRules _staffBusinessRules;

        public UpdateStaffCommandHandler(IMapper mapper, IStaffRepository staffRepository,
                                         StaffBusinessRules staffBusinessRules)
        {
            _mapper = mapper;
            _staffRepository = staffRepository;
            _staffBusinessRules = staffBusinessRules;
        }

        public async Task<UpdatedStaffResponse> Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
        {
            Staff? staff = await _staffRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _staffBusinessRules.StaffShouldExistWhenSelected(staff);
            staff = _mapper.Map(request, staff);

            await _staffRepository.UpdateAsync(staff!);

            UpdatedStaffResponse response = _mapper.Map<UpdatedStaffResponse>(staff);
            return response;
        }
    }
}