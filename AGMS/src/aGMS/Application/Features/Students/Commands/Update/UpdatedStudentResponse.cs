using NArchitecture.Core.Application.Responses;

namespace Application.Features.Students.Commands.Update;
using Domain.Enums;
public class UpdatedStudentResponse : IResponse
{
    public Guid Id { get; set; }
    public string StudentNumber { get; set; }
    public Guid DepartmentId { get; set; }
    public DateTime EnrollDate { get; set; }
    public StudentStatus StudentStatus { get; set; }
    public GraduationStatus GraduationStatus { get; set; }
    public Guid AssignedAdvisorId { get; set; }
    public Guid RequiredCourseListId { get; set; }
}   