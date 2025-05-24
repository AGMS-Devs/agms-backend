using Application.Features.FacultyDeansOffices.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FacultyDeansOffices;

public class FacultyDeansOfficeManager : IFacultyDeansOfficeService
{
    private readonly IFacultyDeansOfficeRepository _facultyDeansOfficeRepository;
    private readonly FacultyDeansOfficeBusinessRules _facultyDeansOfficeBusinessRules;

    public FacultyDeansOfficeManager(IFacultyDeansOfficeRepository facultyDeansOfficeRepository, FacultyDeansOfficeBusinessRules facultyDeansOfficeBusinessRules)
    {
        _facultyDeansOfficeRepository = facultyDeansOfficeRepository;
        _facultyDeansOfficeBusinessRules = facultyDeansOfficeBusinessRules;
    }

    public async Task<FacultyDeansOffice?> GetAsync(
        Expression<Func<FacultyDeansOffice, bool>> predicate,
        Func<IQueryable<FacultyDeansOffice>, IIncludableQueryable<FacultyDeansOffice, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        FacultyDeansOffice? facultyDeansOffice = await _facultyDeansOfficeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return facultyDeansOffice;
    }

    public async Task<IPaginate<FacultyDeansOffice>?> GetListAsync(
        Expression<Func<FacultyDeansOffice, bool>>? predicate = null,
        Func<IQueryable<FacultyDeansOffice>, IOrderedQueryable<FacultyDeansOffice>>? orderBy = null,
        Func<IQueryable<FacultyDeansOffice>, IIncludableQueryable<FacultyDeansOffice, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<FacultyDeansOffice> facultyDeansOfficeList = await _facultyDeansOfficeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return facultyDeansOfficeList;
    }

    public async Task<FacultyDeansOffice> AddAsync(FacultyDeansOffice facultyDeansOffice)
    {
        FacultyDeansOffice addedFacultyDeansOffice = await _facultyDeansOfficeRepository.AddAsync(facultyDeansOffice);

        return addedFacultyDeansOffice;
    }

    public async Task<FacultyDeansOffice> UpdateAsync(FacultyDeansOffice facultyDeansOffice)
    {
        FacultyDeansOffice updatedFacultyDeansOffice = await _facultyDeansOfficeRepository.UpdateAsync(facultyDeansOffice);

        return updatedFacultyDeansOffice;
    }

    public async Task<FacultyDeansOffice> DeleteAsync(FacultyDeansOffice facultyDeansOffice, bool permanent = false)
    {
        FacultyDeansOffice deletedFacultyDeansOffice = await _facultyDeansOfficeRepository.DeleteAsync(facultyDeansOffice);

        return deletedFacultyDeansOffice;
    }
}
