using NArchitecture.Core.Persistence.Repositories;
using System;

namespace Domain.Entities;

public class Department : Entity<Guid>
{
    public string DepartmentName { get; set; } = string.Empty;
    public string DepartmentPhone { get; set; } = string.Empty;
    public Guid FacultyId { get; set; }
    public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    public ICollection<Staff> Staffs { get; set; } = new HashSet<Staff>();
    public ICollection<Advisor> Advisors { get; set; } = new HashSet<Advisor>();
    public virtual FacultyDeansOffice FacultyDeansOffice { get; set; }    
    
    public Department()
    {
        Students = new HashSet<Student>();
        Staffs = new HashSet<Staff>();
        Advisors = new HashSet<Advisor>();
    }

    public Department(Guid id,  string departmentName, string departmentPhone, Guid facultyId)
    {
        Id = id;
        DepartmentName = departmentName;
        DepartmentPhone = departmentPhone;
        FacultyId = facultyId;
        Students = new HashSet<Student>();
        Staffs = new HashSet<Staff>();
        Advisors = new HashSet<Advisor>();
    }

} 