using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Course : Entity<Guid>
{
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public string CourseDescription { get; set; }
    public int CourseCredit { get; set; }
    public int TeoricHours { get; set; }
    public int PracticalHours { get; set; }
    public int ECTS { get; set; }
    public string HalfYear { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid FacultyId { get; set; }

    // Navigation Properties
    public virtual Department Department { get; set; }
    public virtual FacultyDeansOffice FacultyDeansOffice { get; set; }
    public virtual ICollection<RequiredCourseList> RequiredCourseLists { get; set; }
    public virtual ICollection<RequiredCourseListCourse> RequiredCourseListCourses { get; set; }

    public Course()
    {
        RequiredCourseLists = new HashSet<RequiredCourseList>();
        RequiredCourseListCourses = new HashSet<RequiredCourseListCourse>();
    }

    public Course(
        Guid id,
        string courseName,
        string courseCode,
        string courseDescription,
        int courseCredit,
        int teoricHours,
        int practicalHours,
        int ects,
        string halfYear,
        Guid departmentId,
        Guid facultyId
    ) : this()
    {
        Id = id;
        CourseName = courseName;
        CourseCode = courseCode;
        CourseDescription = courseDescription;
        CourseCredit = courseCredit;
        TeoricHours = teoricHours;
        PracticalHours = practicalHours;
        ECTS = ects;
        HalfYear = halfYear;
        DepartmentId = departmentId;
        FacultyId = facultyId;
    }
}
