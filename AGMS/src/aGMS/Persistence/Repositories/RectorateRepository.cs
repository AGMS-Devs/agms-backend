using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RectorateRepository : EfRepositoryBase<Rectorate, Guid, BaseDbContext>, IRectorateRepository
{
    public RectorateRepository(BaseDbContext context) : base(context)
    {
    }
}