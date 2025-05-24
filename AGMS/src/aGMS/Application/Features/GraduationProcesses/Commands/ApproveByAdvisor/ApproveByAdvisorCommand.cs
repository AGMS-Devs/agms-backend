using Application.Features.GraduationProcesses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.GraduationProcesses.Commands.ApproveByAdvisor;

public class ApproveByAdvisorCommand : IRequest<ApprovedByAdvisorResponse>
{
    public Guid GraduationProcessId { get; set; }
    public bool IsApproved { get; set; }

    public class ApproveByAdvisorCommandHandler : IRequestHandler<ApproveByAdvisorCommand, ApprovedByAdvisorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationProcessRepository _graduationProcessRepository;
        private readonly IAdvisorRepository _advisorRepository;
        private readonly GraduationProcessBusinessRules _graduationProcessBusinessRules;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApproveByAdvisorCommandHandler(
            IMapper mapper, 
            IGraduationProcessRepository graduationProcessRepository,
            IAdvisorRepository advisorRepository,
            GraduationProcessBusinessRules graduationProcessBusinessRules,
            IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _graduationProcessRepository = graduationProcessRepository;
            _advisorRepository = advisorRepository;
            _graduationProcessBusinessRules = graduationProcessBusinessRules;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApprovedByAdvisorResponse> Handle(ApproveByAdvisorCommand request, CancellationToken cancellationToken)
        {
            GraduationProcess? graduationProcess = await _graduationProcessRepository.GetAsync(
                predicate: gp => gp.Id == request.GraduationProcessId, 
                cancellationToken: cancellationToken);
            
            await _graduationProcessBusinessRules.GraduationProcessShouldExistWhenSelected(graduationProcess);

            // Kullanıcının advisor olup olmadığını ve bu graduation process'i onaylayıp onaylayamayacağını kontrol et
            await _graduationProcessBusinessRules.UserShouldBeAuthorizedForAdvisorApproval(graduationProcess!, _httpContextAccessor.HttpContext!.User);

            graduationProcess!.AdvisorApproved = request.IsApproved;
            if (request.IsApproved)
            {
                graduationProcess.AdvisorApprovedDate = DateTime.UtcNow;
            }

            await _graduationProcessRepository.UpdateAsync(graduationProcess);

            ApprovedByAdvisorResponse response = _mapper.Map<ApprovedByAdvisorResponse>(graduationProcess);
            return response;
        }
    }
} 