using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FacultyDeansOfficeRepository : EfRepositoryBase<FacultyDeansOffice, Guid, BaseDbContext>, IFacultyDeansOfficeRepository
{
    public FacultyDeansOfficeRepository(BaseDbContext context) : base(context)
    {
    }
}