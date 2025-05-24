using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AdvisorRepository : EfRepositoryBase<Advisor, Guid, BaseDbContext>, IAdvisorRepository
{
    public AdvisorRepository(BaseDbContext context) : base(context)
    {
    }
}