namespace Application.Features.RequiredCourseLists.Queries.GetByStudent;

public class GetRequiredCourseListByStudentResponse
{
    public Guid StudentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<RequiredCourseDto> RequiredCourses { get; set; }
}

public class RequiredCourseDto
{
    public Guid Id { get; set; }
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public int CourseCredit { get; set; }
    public string HalfYear { get; set; }
    public string CourseDescription { get; set; }
    public int TeoricHours { get; set; }
    public int PracticalHours { get; set; }
    public int ECTS { get; set; }
} 