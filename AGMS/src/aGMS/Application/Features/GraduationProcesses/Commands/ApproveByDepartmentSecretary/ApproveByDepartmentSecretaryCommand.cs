using Application.Features.GraduationProcesses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.GraduationProcesses.Commands.ApproveByDepartmentSecretary;

public class ApproveByDepartmentSecretaryCommand : IRequest<ApprovedByDepartmentSecretaryResponse>
{
    public Guid GraduationProcessId { get; set; }
    public bool IsApproved { get; set; }

    public class ApproveByDepartmentSecretaryCommandHandler : IRequestHandler<ApproveByDepartmentSecretaryCommand, ApprovedByDepartmentSecretaryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationProcessRepository _graduationProcessRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly GraduationProcessBusinessRules _graduationProcessBusinessRules;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApproveByDepartmentSecretaryCommandHandler(
            IMapper mapper, 
            IGraduationProcessRepository graduationProcessRepository,
            IStaffRepository staffRepository,
            GraduationProcessBusinessRules graduationProcessBusinessRules,
            IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _graduationProcessRepository = graduationProcessRepository;
            _staffRepository = staffRepository;
            _graduationProcessBusinessRules = graduationProcessBusinessRules;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApprovedByDepartmentSecretaryResponse> Handle(ApproveByDepartmentSecretaryCommand request, CancellationToken cancellationToken)
        {
            GraduationProcess? graduationProcess = await _graduationProcessRepository.GetAsync(
                predicate: gp => gp.Id == request.GraduationProcessId, 
                cancellationToken: cancellationToken);
            
            await _graduationProcessBusinessRules.GraduationProcessShouldExistWhenSelected(graduationProcess);

            // Kullanıcının DepartmentSecretary rolünde staff olup olmadığını kontrol et
            await _graduationProcessBusinessRules.UserShouldBeAuthorizedForDepartmentSecretaryApproval(graduationProcess!, _httpContextAccessor.HttpContext!.User);

            graduationProcess!.DepartmentSecretaryApproved = request.IsApproved;
            if (request.IsApproved)
            {
                graduationProcess.DepartmentSecretaryApprovedDate = DateTime.UtcNow;
            }

            await _graduationProcessRepository.UpdateAsync(graduationProcess);

            ApprovedByDepartmentSecretaryResponse response = _mapper.Map<ApprovedByDepartmentSecretaryResponse>(graduationProcess);
            return response;
        }
    }
} 