using System;
using NArchitecture.Core.Persistence.Repositories;
namespace Domain.Entities;

public class Advisor : Entity<Guid>
{

    public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    public Guid DepartmentId { get; set; }
    public virtual Department Department { get; set; }
    public virtual User User { get; set; }
    public virtual GraduationList GraduationList { get; set; }

    public Advisor()
    {

    }
    
    public Advisor(Guid userId, ICollection<Student> students, Guid departmentId)
    {
        Id = userId;
        Students = new HashSet<Student>(students);
        DepartmentId = departmentId;  
    }

} 