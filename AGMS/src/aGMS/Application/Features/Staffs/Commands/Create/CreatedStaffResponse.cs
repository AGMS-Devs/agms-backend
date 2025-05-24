using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using Domain.Enums;
namespace Application.Features.Staffs.Commands.Create;

public class CreatedStaffResponse : IResponse
{
    public Guid Id { get; set; }
    public string StaffPhone { get; set; }
    public StaffRole StaffRole { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? FacultyId { get; set; }
}