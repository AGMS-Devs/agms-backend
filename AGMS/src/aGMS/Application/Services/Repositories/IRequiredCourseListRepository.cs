using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRequiredCourseListRepository : IAsyncRepository<RequiredCourseList, Guid>, IRepository<RequiredCourseList, Guid>
{
}