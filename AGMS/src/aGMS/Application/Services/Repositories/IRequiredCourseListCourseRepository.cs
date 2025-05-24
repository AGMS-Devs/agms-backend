using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRequiredCourseListCourseRepository : IAsyncRepository<RequiredCourseListCourse, Guid>, IRepository<RequiredCourseListCourse, Guid>
{
}