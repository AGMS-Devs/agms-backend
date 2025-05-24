using NArchitecture.Core.Application.Dtos;
using Domain.Enums;
namespace Application.Features.Students.Queries.GetList;

public class GetListStudentListItemDto : IDto
{
    public Guid Id { get; set; }
    public string StudentNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Guid DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public DateTime EnrollDate { get; set; }
    public StudentStatus StudentStatus { get; set; }
    public GraduationStatus GraduationStatus { get; set; }
    public Guid AssignedAdvisorId { get; set; }
    public string AdvisorName { get; set; }
    public string AdvisorSurname { get; set; }
    public Guid RequiredCourseListId { get; set; }
}
