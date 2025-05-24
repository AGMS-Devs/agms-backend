using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentAffairRepository : EfRepositoryBase<StudentAffair, Guid, BaseDbContext>, IStudentAffairRepository
{
    public StudentAffairRepository(BaseDbContext context) : base(context)
    {
    }
}