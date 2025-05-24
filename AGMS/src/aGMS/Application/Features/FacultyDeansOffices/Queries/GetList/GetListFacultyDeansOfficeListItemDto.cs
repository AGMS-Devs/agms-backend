using NArchitecture.Core.Application.Dtos;
using Application.Features.FacultyDeansOffices.Queries.GetById;

namespace Application.Features.FacultyDeansOffices.Queries.GetList;

public class GetListFacultyDeansOfficeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string FacultyName { get; set; }
    public Guid StudentAffairId { get; set; }
    public List<FacultyDepartmentDto> Departments { get; set; } = new List<FacultyDepartmentDto>();
}