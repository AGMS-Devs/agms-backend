using NArchitecture.Core.Persistence.Repositories;
using Domain.Enums;
namespace Domain.Entities;
public class Staff : Entity<Guid>
{


    public string StaffPhone { get; set; } = string.Empty;
    public StaffRole StaffRole { get; set; }

    public Guid? DepartmentId { get; set; }
    public Guid? FacultyId { get; set; }

    public virtual User User { get; set; }
    
    // TopStudentList ilişkileri
    public virtual ICollection<TopStudentList> StudentAffairsTopStudentLists { get; set; } = new HashSet<TopStudentList>();
    public virtual ICollection<TopStudentList> RectorateTopStudentLists { get; set; } = new HashSet<TopStudentList>();

    public Staff()
    {
        StudentAffairsTopStudentLists = new HashSet<TopStudentList>();
        RectorateTopStudentLists = new HashSet<TopStudentList>();
    }
    
    public Staff(Guid userId, string staffPhone, StaffRole staffRole, Guid? departmentId, Guid? facultyId)
    {
        Id = userId;
        StaffPhone = staffPhone;
        StaffRole = staffRole;
        DepartmentId = departmentId;
        FacultyId = facultyId;
        StaffRole = staffRole;
        StudentAffairsTopStudentLists = new HashSet<TopStudentList>();
        RectorateTopStudentLists = new HashSet<TopStudentList>();
    }
}
