using NArchitecture.Core.Persistence.Repositories;
using System;

namespace Domain.Entities;

public class GraduationList : Entity<Guid>
{
    public string GraduationListNumber { get; set; } = string.Empty;
    
    public Guid AdvisorId { get; set; }
    public Advisor Advisor { get; set; }
    
    public ICollection<GraduationProcess> GraduationProcesses { get; set; } = new HashSet<GraduationProcess>();

    public GraduationList()
    {

    }

    public GraduationList(string graduationListNumber, Guid advisorId)
    {
        GraduationListNumber = graduationListNumber;
        AdvisorId = advisorId;
    }
}