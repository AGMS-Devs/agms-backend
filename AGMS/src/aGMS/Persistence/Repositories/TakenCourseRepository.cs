using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TakenCourseRepository : EfRepositoryBase<TakenCourse, Guid, BaseDbContext>, ITakenCourseRepository
{
    public TakenCourseRepository(BaseDbContext context) : base(context)
    {
    }
}