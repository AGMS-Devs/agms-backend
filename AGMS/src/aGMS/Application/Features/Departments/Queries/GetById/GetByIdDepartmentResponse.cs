using NArchitecture.Core.Application.Responses;

namespace Application.Features.Departments.Queries.GetById;

public class GetByIdDepartmentResponse : IResponse
{
    public Guid Id { get; set; }
    public string DepartmentName { get; set; }
    public string DepartmentPhone { get; set; }
    public Guid FacultyId { get; set; }
}