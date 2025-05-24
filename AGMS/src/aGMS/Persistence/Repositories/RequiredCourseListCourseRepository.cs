using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RequiredCourseListCourseRepository : EfRepositoryBase<RequiredCourseListCourse, Guid, BaseDbContext>, IRequiredCourseListCourseRepository
{
    public RequiredCourseListCourseRepository(BaseDbContext context) : base(context)
    {
    }
}