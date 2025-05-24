namespace Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
public class GraduationProcess : Entity<Guid>
{

    public bool AdvisorApproved { get; set; } = false;
    public DateTime AdvisorApprovedDate { get; set; }
    public bool DepartmentSecretaryApproved { get; set; } = false;
    public DateTime DepartmentSecretaryApprovedDate { get; set; }
    public bool FacultyDeansOfficeApproved { get; set; } = false;
    public DateTime FacultyDeansOfficeApprovedDate { get; set; }
    public bool StudentAffairsApproved { get; set; } = false;
    public DateTime StudentAffairsApprovedDate { get; set; }

    public Guid StudentId { get; set; }
    public virtual User StudentUser { get; set; }
    public Guid GraduationListId { get; set; }
    public virtual GraduationList GraduationList { get; set; }

    public GraduationProcess()
    {

    }

    public GraduationProcess(Guid studentId, Guid graduationListId, bool advisorApproved, bool departmentSecretaryApproved, bool facultyDeansOfficeApproved, bool studentAffairsApproved)
    {
        StudentId = studentId;
        GraduationListId = graduationListId;
        AdvisorApproved = advisorApproved;
        DepartmentSecretaryApproved = departmentSecretaryApproved;
        FacultyDeansOfficeApproved = facultyDeansOfficeApproved;
        StudentAffairsApproved = studentAffairsApproved;
    }
    
    
}
