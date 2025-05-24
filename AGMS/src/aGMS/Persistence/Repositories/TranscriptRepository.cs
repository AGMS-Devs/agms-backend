using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TranscriptRepository : EfRepositoryBase<Transcript, Guid, BaseDbContext>, ITranscriptRepository
{
    public TranscriptRepository(BaseDbContext context) : base(context)
    {
    }
}