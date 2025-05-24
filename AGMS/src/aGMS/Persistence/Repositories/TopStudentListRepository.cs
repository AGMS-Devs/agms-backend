using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TopStudentListRepository : EfRepositoryBase<TopStudentList, Guid, BaseDbContext>, ITopStudentListRepository
{
    public TopStudentListRepository(BaseDbContext context) : base(context)
    {
    }
}