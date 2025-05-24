using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FacultyDeansOffices;

public interface IFacultyDeansOfficeService
{
    Task<FacultyDeansOffice?> GetAsync(
        Expression<Func<FacultyDeansOffice, bool>> predicate,
        Func<IQueryable<FacultyDeansOffice>, IIncludableQueryable<FacultyDeansOffice, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<FacultyDeansOffice>?> GetListAsync(
        Expression<Func<FacultyDeansOffice, bool>>? predicate = null,
        Func<IQueryable<FacultyDeansOffice>, IOrderedQueryable<FacultyDeansOffice>>? orderBy = null,
        Func<IQueryable<FacultyDeansOffice>, IIncludableQueryable<FacultyDeansOffice, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<FacultyDeansOffice> AddAsync(FacultyDeansOffice facultyDeansOffice);
    Task<FacultyDeansOffice> UpdateAsync(FacultyDeansOffice facultyDeansOffice);
    Task<FacultyDeansOffice> DeleteAsync(FacultyDeansOffice facultyDeansOffice, bool permanent = false);
}
