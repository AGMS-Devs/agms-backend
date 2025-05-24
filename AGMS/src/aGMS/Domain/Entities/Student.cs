using NArchitecture.Core.Persistence.Repositories;
using Domain.Enums; // Namespace düzeltildi
using System.ComponentModel.DataAnnotations.Schema; // ForeignKey attribute'u için eklendi

namespace Domain.Entities; // Namespace düzeltildi

public class Student : Entity<Guid> // UserId olacak primary key ve User'a FK
{
    // UserId (Guid, Primary Key, FK to User.Id) - Entity<Guid> Id olarak bunu kullanır.
    // Bu yüzden Id alanı User.Id ile aynı değere sahip olmalı.
    public string StudentNumber { get; set; }
    public Guid DepartmentId { get; set; } // _fk kaldırıldı, PascalCase
    public DateTime EnrollDate { get; set; } // Date yerine DateTime kullandım, gerekirse DateOnly'ye çevrilebilir.
    public StudentStatus StudentStatus { get; set; } = StudentStatus.Active;
    public GraduationStatus GraduationStatus { get; set; }
    public Guid AssignedAdvisorId { get; set; }
    public Guid RequiredCourseListId { get; set; }

    // İlişki (Navigation Property)
    public virtual User User { get; set; }
    public virtual Department Department { get; set; }

    [ForeignKey("AssignedAdvisorId")]
    public virtual Advisor AssignedAdvisor { get; set; }
    
    [ForeignKey("RequiredCourseListId")]
    public virtual RequiredCourseList RequiredCourseList { get; set; }
    
    public ICollection<TakenCourse> TakenCourses { get; set; } = new HashSet<TakenCourse>();

    public Student()    
    {
    }

    public Student(Guid userId, string studentNumber, Guid departmentId, DateTime enrollDate, StudentStatus studentStatus, GraduationStatus graduationStatus, Guid assignedAdvisorId, Guid requiredCourseListId)
    {
        Id = userId; // Set the Id to UserId for TPT
        StudentNumber = studentNumber;
        DepartmentId = departmentId;
        EnrollDate = enrollDate;
        StudentStatus = studentStatus;
        GraduationStatus = graduationStatus;
        AssignedAdvisorId = assignedAdvisorId;
        RequiredCourseListId = requiredCourseListId;
    }
} 