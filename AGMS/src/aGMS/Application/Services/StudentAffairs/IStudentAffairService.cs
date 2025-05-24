using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentAffairs;

public interface IStudentAffairService
{
    Task<StudentAffair?> GetAsync(
        Expression<Func<StudentAffair, bool>> predicate,
        Func<IQueryable<StudentAffair>, IIncludableQueryable<StudentAffair, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StudentAffair>?> GetListAsync(
        Expression<Func<StudentAffair, bool>>? predicate = null,
        Func<IQueryable<StudentAffair>, IOrderedQueryable<StudentAffair>>? orderBy = null,
        Func<IQueryable<StudentAffair>, IIncludableQueryable<StudentAffair, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StudentAffair> AddAsync(StudentAffair studentAffair);
    Task<StudentAffair> UpdateAsync(StudentAffair studentAffair);
    Task<StudentAffair> DeleteAsync(StudentAffair studentAffair, bool permanent = false);
}
