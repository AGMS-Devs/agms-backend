using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Courses.Queries.GetList;

public class GetListCourseListItemDto : IDto
{
    public Guid Id { get; set; }
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public int TeoricHours { get; set; }
    public int PracticalHours { get; set; }
    public int ECTS { get; set; }
    public string HalfYear { get; set; }
    public string CourseDescription { get; set; }
    public int CourseCredit { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid FacultyId { get; set; }
}