using System;
using NArchitecture.Core.Persistence.Repositories;
namespace Domain.Entities;

public class StudentAffair : Entity<Guid>
{
    public string OfficeName { get; set; } = string.Empty;
    public ICollection<FacultyDeansOffice> FacultyDeansOffices { get; set; } = new HashSet<FacultyDeansOffice>();
    public ICollection<Ceremony> Ceremonies { get; set; } = new HashSet<Ceremony>();

    public StudentAffair()
    {
        FacultyDeansOffices = new HashSet<FacultyDeansOffice>();
        Ceremonies = new HashSet<Ceremony>();
    }

    public StudentAffair(Guid id, string officeName)
    {
        Id = id;
        OfficeName = officeName;
        FacultyDeansOffices = new HashSet<FacultyDeansOffice>();
        Ceremonies = new HashSet<Ceremony>();
    }
} 