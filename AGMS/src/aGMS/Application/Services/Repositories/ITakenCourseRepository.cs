using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITakenCourseRepository : IAsyncRepository<TakenCourse, Guid>, IRepository<TakenCourse, Guid>
{
}