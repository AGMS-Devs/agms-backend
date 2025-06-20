using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GraduationListRepository : EfRepositoryBase<GraduationList, Guid, BaseDbContext>, IGraduationListRepository
{
    public GraduationListRepository(BaseDbContext context) : base(context)
    {
    }
}