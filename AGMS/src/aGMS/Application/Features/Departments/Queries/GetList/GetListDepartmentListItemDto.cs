using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Departments.Queries.GetList;

public class GetListDepartmentListItemDto : IDto
{
    public Guid Id { get; set; }
    public string DepartmentName { get; set; }
    public string DepartmentPhone { get; set; }
    public Guid FacultyId { get; set; }
}