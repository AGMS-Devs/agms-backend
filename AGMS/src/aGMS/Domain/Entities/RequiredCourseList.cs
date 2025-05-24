using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class RequiredCourseList : Entity<Guid>
{
    public string Name { get; set; } = string.Empty; // Ör: "Bilgisayar Mühendisliği 1. Sınıf"
    public string Description { get; set; } = string.Empty;

    // Navigation Properties
    public virtual ICollection<Student> Students { get; set; }
    public virtual ICollection<Course> Courses { get; set; }
    public virtual ICollection<RequiredCourseListCourse> RequiredCourseListCourses { get; set; }

    public RequiredCourseList()
    {
        Students = new HashSet<Student>();
        Courses = new HashSet<Course>();
        RequiredCourseListCourses = new HashSet<RequiredCourseListCourse>();
    }

    public RequiredCourseList(Guid id, string name, string description) : this()
    {
        Id = id;
        Name = name;
        Description = description;
    }
}
