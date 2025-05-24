using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RequiredCourseListRepository : EfRepositoryBase<RequiredCourseList, Guid, BaseDbContext>, IRequiredCourseListRepository
{
    public RequiredCourseListRepository(BaseDbContext context) : base(context)
    {
    }
}