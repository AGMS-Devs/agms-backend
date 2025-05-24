using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFacultyDeansOfficeRepository : IAsyncRepository<FacultyDeansOffice, Guid>, IRepository<FacultyDeansOffice, Guid>
{
}