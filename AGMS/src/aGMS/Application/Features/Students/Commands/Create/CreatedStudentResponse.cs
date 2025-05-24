using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Students.Commands.Create;

public class CreatedStudentResponse : IResponse
{
    public Guid Id { get; set; }
    public string StudentNumber { get; set; }
    public Guid DepartmentId { get; set; }
    public DateTime EnrollDate { get; set; }
    public Guid RequiredCourseListId { get; set; }
    public StudentStatus StudentStatus { get; set; }
    public GraduationStatus GraduationStatus { get; set; }
    public Guid AssignedAdvisorId { get; set; }
    public DateTime CreatedDate { get; set; }
}