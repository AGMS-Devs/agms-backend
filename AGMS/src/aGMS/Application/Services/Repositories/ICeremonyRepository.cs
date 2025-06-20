using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICeremonyRepository : IAsyncRepository<Ceremony, Guid>, IRepository<Ceremony, Guid>
{
}