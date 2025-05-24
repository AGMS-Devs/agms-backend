using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class RequiredCourseListCourse : Entity<Guid>
{
    public Guid RequiredCourseListId { get; set; }
    public Guid CourseId { get; set; }

    // Navigation Properties
    public virtual RequiredCourseList RequiredCourseList { get; set; }
    public virtual Course Course { get; set; }

    public RequiredCourseListCourse()
    {
        CreatedDate = DateTime.UtcNow;
    }

    public RequiredCourseListCourse(Guid requiredCourseListId, Guid courseId) : this()
    {
        RequiredCourseListId = requiredCourseListId;
        CourseId = courseId;
    }
} 