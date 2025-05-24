using NArchitecture.Core.Application.Dtos;
using Domain.Enums;
namespace Application.Features.Staffs.Queries.GetList;

public class GetListStaffListItemDto : IDto
{
    public Guid Id { get; set; }
    public string StaffPhone { get; set; }
    public StaffRole StaffRole { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? FacultyId { get; set; }
}