using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITranscriptRepository : IAsyncRepository<Transcript, Guid>, IRepository<Transcript, Guid>
{
}