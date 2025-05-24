using System;
using NArchitecture.Core.Persistence.Repositories;
namespace Domain.Entities;

public class FacultyDeansOffice : Entity<Guid>
{
    public string FacultyName { get; set; } = string.Empty;
    public Guid StudentAffairId { get; set; }
    public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    public virtual StudentAffair StudentAffair { get; set; }

    public FacultyDeansOffice()
    {
        Departments = new HashSet<Department>();
    }

    public FacultyDeansOffice(Guid id, string facultyName, Guid studentAffairId)
    {
        Id = id;
        FacultyName = facultyName;
        StudentAffairId = studentAffairId;
        Departments = new HashSet<Department>();
        StudentAffair = new StudentAffair();
    }


} 