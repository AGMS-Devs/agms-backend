using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRectorateRepository : IAsyncRepository<Rectorate, Guid>, IRepository<Rectorate, Guid>
{
}