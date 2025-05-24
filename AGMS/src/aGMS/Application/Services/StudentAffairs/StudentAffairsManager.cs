using Application.Features.StudentAffairs.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentAffairs;

public class StudentAffairsManager : IStudentAffairService
{
    private readonly IStudentAffairRepository _studentAffairRepository;
    private readonly StudentAffairsBusinessRules _studentAffairsBusinessRules;

    public StudentAffairsManager(IStudentAffairRepository studentAffairRepository, StudentAffairsBusinessRules studentAffairsBusinessRules)
    {
        _studentAffairRepository = studentAffairRepository;
        _studentAffairsBusinessRules = studentAffairsBusinessRules;
    }

    public async Task<StudentAffair?> GetAsync(
        Expression<Func<StudentAffair, bool>> predicate,
        Func<IQueryable<StudentAffair>, IIncludableQueryable<StudentAffair, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StudentAffair? studentAffair = await _studentAffairRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return studentAffair;
    }

    public async Task<IPaginate<StudentAffair>?> GetListAsync(
        Expression<Func<StudentAffair, bool>>? predicate = null,
        Func<IQueryable<StudentAffair>, IOrderedQueryable<StudentAffair>>? orderBy = null,
        Func<IQueryable<StudentAffair>, IIncludableQueryable<StudentAffair, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StudentAffair> studentAffairList = await _studentAffairRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return studentAffairList;
    }

    public async Task<StudentAffair> AddAsync(StudentAffair studentAffair)
    {
        StudentAffair addedStudentAffair = await _studentAffairRepository.AddAsync(studentAffair);

        return addedStudentAffair;
    }

    public async Task<StudentAffair> UpdateAsync(StudentAffair studentAffair)
    {
        StudentAffair updatedStudentAffair = await _studentAffairRepository.UpdateAsync(studentAffair);

        return updatedStudentAffair;
    }

    public async Task<StudentAffair> DeleteAsync(StudentAffair studentAffair, bool permanent = false)
    {
        StudentAffair deletedStudentAffair = await _studentAffairRepository.DeleteAsync(studentAffair);

        return deletedStudentAffair;
    }
}
