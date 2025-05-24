using Application.Features.Advisors.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Advisors;

public class AdvisorManager : IAdvisorService
{
    private readonly IAdvisorRepository _advisorRepository;
    private readonly AdvisorBusinessRules _advisorBusinessRules;

    public AdvisorManager(IAdvisorRepository advisorRepository, AdvisorBusinessRules advisorBusinessRules)
    {
        _advisorRepository = advisorRepository;
        _advisorBusinessRules = advisorBusinessRules;
    }

    public async Task<Advisor?> GetAsync(
        Expression<Func<Advisor, bool>> predicate,
        Func<IQueryable<Advisor>, IIncludableQueryable<Advisor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Advisor? advisor = await _advisorRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return advisor;
    }

    public async Task<IPaginate<Advisor>?> GetListAsync(
        Expression<Func<Advisor, bool>>? predicate = null,
        Func<IQueryable<Advisor>, IOrderedQueryable<Advisor>>? orderBy = null,
        Func<IQueryable<Advisor>, IIncludableQueryable<Advisor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Advisor> advisorList = await _advisorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return advisorList;
    }

    public async Task<Advisor> AddAsync(Advisor advisor)
    {
        Advisor addedAdvisor = await _advisorRepository.AddAsync(advisor);

        return addedAdvisor;
    }

    public async Task<Advisor> UpdateAsync(Advisor advisor)
    {
        Advisor updatedAdvisor = await _advisorRepository.UpdateAsync(advisor);

        return updatedAdvisor;
    }

    public async Task<Advisor> DeleteAsync(Advisor advisor, bool permanent = false)
    {
        Advisor deletedAdvisor = await _advisorRepository.DeleteAsync(advisor);

        return deletedAdvisor;
    }
}
