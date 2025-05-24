using NArchitecture.Core.Application.Responses;

namespace Application.Features.Departments.Commands.Update;

public class UpdatedDepartmentResponse : IResponse
{
    public Guid Id { get; set; }
    public string DepartmentName { get; set; }
    public string DepartmentPhone { get; set; }
    public Guid FacultyId { get; set; }
}