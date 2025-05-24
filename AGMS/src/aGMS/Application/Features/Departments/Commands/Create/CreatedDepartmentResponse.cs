using NArchitecture.Core.Application.Responses;

namespace Application.Features.Departments.Commands.Create;

public class CreatedDepartmentResponse : IResponse
{
    public Guid Id { get; set; }
    public string DepartmentName { get; set; }
    public string DepartmentPhone { get; set; }
    public Guid FacultyId { get; set; }
}