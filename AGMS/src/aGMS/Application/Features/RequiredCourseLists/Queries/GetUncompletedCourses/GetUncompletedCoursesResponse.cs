namespace Application.Features.RequiredCourseLists.Queries.GetUncompletedCourses;

public class GetUncompletedCoursesResponse
{
    public Guid StudentId { get; set; }
    public List<UncompletedCourseDto> UncompletedCourses { get; set; }
}

public class UncompletedCourseDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int Credit { get; set; }
    public bool IsCompulsory { get; set; }
    public string Semester { get; set; }
} 