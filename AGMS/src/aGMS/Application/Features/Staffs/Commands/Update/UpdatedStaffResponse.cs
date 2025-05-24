using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using Domain.Enums;
namespace Application.Features.Staffs.Commands.Update;

public class UpdatedStaffResponse : IResponse
{
    public Guid Id { get; set; }
    public string StaffPhone { get; set; }
    public StaffRole StaffRole { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? FacultyId { get; set; }
}