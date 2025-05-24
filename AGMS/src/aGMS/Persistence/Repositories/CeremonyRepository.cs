using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CeremonyRepository : EfRepositoryBase<Ceremony, Guid, BaseDbContext>, ICeremonyRepository
{
    public CeremonyRepository(BaseDbContext context) : base(context)
    {
    }
}