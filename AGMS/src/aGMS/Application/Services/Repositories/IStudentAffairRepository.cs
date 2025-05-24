using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentAffairRepository : IAsyncRepository<StudentAffair, Guid>, IRepository<StudentAffair, Guid>
{
}