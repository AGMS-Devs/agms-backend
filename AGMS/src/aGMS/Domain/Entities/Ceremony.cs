using System;
using NArchitecture.Core.Persistence.Repositories;
using Domain.Enums;
namespace Domain.Entities;

public class Ceremony : Entity<Guid>
{

    public DateTime CeremonyDate { get; set; }
    public string CeremonyLocation { get; set; } = string.Empty;
    public string CeremonyDescription { get; set; } = string.Empty;
    public CeremonyStatus CeremonyStatus { get; set; } = CeremonyStatus.Pending;
    public string AcademicYear { get; set; } = string.Empty;
    public ICollection<User> StudentUsers { get; set; } = new HashSet<User>();
    public Guid StudentAffairId { get; set; }
    public virtual StudentAffair StudentAffair { get; set; }
    public Ceremony()
    {
        StudentUsers = new HashSet<User>();
    }

    public Ceremony(Guid id, DateTime ceremonyDate, string ceremonyLocation, string ceremonyDescription, CeremonyStatus ceremonyStatus, string academicYear, Guid studentAffairId)
    {
        Id = id;
        CeremonyDate = ceremonyDate;
        CeremonyLocation = ceremonyLocation;
        CeremonyDescription = ceremonyDescription;
        CeremonyStatus = ceremonyStatus;
        AcademicYear = academicYear;
        StudentUsers = new HashSet<User>();
        StudentAffairId = studentAffairId;
    }
}
