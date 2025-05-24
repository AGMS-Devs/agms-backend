using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAdvisorRepository : IAsyncRepository<Advisor, Guid>, IRepository<Advisor, Guid>
{
}