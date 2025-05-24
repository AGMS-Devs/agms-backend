using System;
using NArchitecture.Core.Persistence.Repositories;
namespace Domain.Entities;

public class Rectorate : Entity<Guid>
{
    public Guid StudentAffairId { get; set; }
    public virtual StudentAffair StudentAffair { get; set; }

    public Rectorate()
    {

    }

    public Rectorate(Guid id, Guid studentAffairId)
    {
        Id = id;
        StudentAffairId = studentAffairId;
    }
} 