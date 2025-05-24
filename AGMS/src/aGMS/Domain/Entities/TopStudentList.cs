using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class TopStudentList : Entity<Guid>
{

    public TopStudentListType TopStudentListType { get; set; }
    public bool StudentAffairsApproval { get; set; } = false;
    public Guid StudentAffairsStaffId { get; set; }
    public virtual Staff StudentAffairsStaff { get; set; }
    public bool RectorateApproval { get; set; } = false;
    public Guid RectorateStaffId { get; set; }
    public virtual Staff RectorateStaff { get; set; }
    public bool SendRectorate { get; set; } = false;
    public ICollection<Student> Students { get; set; }


    public TopStudentList()
    {
        Students = new HashSet<Student>();
    }

    public TopStudentList(TopStudentListType topStudentListType, bool studentAffairsApproval, bool sendRectorate)
    {
        TopStudentListType = topStudentListType;
        StudentAffairsApproval = studentAffairsApproval;
        SendRectorate = sendRectorate;
    }
}
