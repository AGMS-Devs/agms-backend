using Domain.Enums;

namespace Application.Features.TakenCourses.Queries.GetByStudent;

public class GetTakenCoursesByStudentResponse
{
    public Guid StudentId { get; set; }
    public List<TakenCourseDto> TakenCourses { get; set; }
}

public class TakenCourseDto
{
    public Guid Id { get; set; }
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public int CourseCredit { get; set; }
    public string HalfYear { get; set; }
    public Grade Grade { get; set; }
    public DateTime TakenDate { get; set; }
} 