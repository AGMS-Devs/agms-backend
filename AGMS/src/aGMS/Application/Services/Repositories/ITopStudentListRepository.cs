using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITopStudentListRepository : IAsyncRepository<TopStudentList, Guid>, IRepository<TopStudentList, Guid>
{
}