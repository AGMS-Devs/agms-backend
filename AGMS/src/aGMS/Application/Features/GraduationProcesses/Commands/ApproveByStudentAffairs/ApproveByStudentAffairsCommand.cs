using Application.Features.GraduationProcesses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.GraduationProcesses.Commands.ApproveByStudentAffairs;

public class ApproveByStudentAffairsCommand : IRequest<ApprovedByStudentAffairsResponse>
{
    public Guid GraduationProcessId { get; set; }
    public bool IsApproved { get; set; }

    public class ApproveByStudentAffairsCommandHandler : IRequestHandler<ApproveByStudentAffairsCommand, ApprovedByStudentAffairsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationProcessRepository _graduationProcessRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly GraduationProcessBusinessRules _graduationProcessBusinessRules;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApproveByStudentAffairsCommandHandler(
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

        public async Task<ApprovedByStudentAffairsResponse> Handle(ApproveByStudentAffairsCommand request, CancellationToken cancellationToken)
        {
            GraduationProcess? graduationProcess = await _graduationProcessRepository.GetAsync(
                predicate: gp => gp.Id == request.GraduationProcessId, 
                cancellationToken: cancellationToken);
            
            await _graduationProcessBusinessRules.GraduationProcessShouldExistWhenSelected(graduationProcess);

            // Kullanıcının StudentAffairs rolünde staff olup olmadığını kontrol et
            await _graduationProcessBusinessRules.UserShouldBeAuthorizedForStudentAffairsApproval(graduationProcess!, _httpContextAccessor.HttpContext!.User);

            graduationProcess!.StudentAffairsApproved = request.IsApproved;
            if (request.IsApproved)
            {
                graduationProcess.StudentAffairsApprovedDate = DateTime.UtcNow;
            }

            await _graduationProcessRepository.UpdateAsync(graduationProcess);

            ApprovedByStudentAffairsResponse response = _mapper.Map<ApprovedByStudentAffairsResponse>(graduationProcess);
            return response;
        }
    }
} 