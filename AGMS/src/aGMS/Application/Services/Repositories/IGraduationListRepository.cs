using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IGraduationListRepository : IAsyncRepository<GraduationList, Guid>, IRepository<GraduationList, Guid>
{
}