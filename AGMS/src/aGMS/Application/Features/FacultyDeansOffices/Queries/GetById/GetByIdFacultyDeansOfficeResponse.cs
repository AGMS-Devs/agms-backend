using NArchitecture.Core.Application.Responses;

namespace Application.Features.FacultyDeansOffices.Queries.GetById;

public class GetByIdFacultyDeansOfficeResponse : IResponse
{
    public Guid Id { get; set; }
    public string FacultyName { get; set; }
    public Guid StudentAffairId { get; set; }
    public List<FacultyDepartmentDto> Departments { get; set; } = new List<FacultyDepartmentDto>();
}

public class FacultyDepartmentDto
{
    public Guid Id { get; set; }
    public string DepartmentName { get; set; }
    public string DepartmentPhone { get; set; }
    public Guid FacultyId { get; set; }
}