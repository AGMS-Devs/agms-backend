using Application.Features.GraduationProcesses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.GraduationProcesses.Commands.ApproveByFacultyDeansOffice;

public class ApproveByFacultyDeansOfficeCommand : IRequest<ApprovedByFacultyDeansOfficeResponse>
{
    public Guid GraduationProcessId { get; set; }
    public bool IsApproved { get; set; }

    public class ApproveByFacultyDeansOfficeCommandHandler : IRequestHandler<ApproveByFacultyDeansOfficeCommand, ApprovedByFacultyDeansOfficeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationProcessRepository _graduationProcessRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly GraduationProcessBusinessRules _graduationProcessBusinessRules;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApproveByFacultyDeansOfficeCommandHandler(
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

        public async Task<ApprovedByFacultyDeansOfficeResponse> Handle(ApproveByFacultyDeansOfficeCommand request, CancellationToken cancellationToken)
        {
            GraduationProcess? graduationProcess = await _graduationProcessRepository.GetAsync(
                predicate: gp => gp.Id == request.GraduationProcessId, 
                cancellationToken: cancellationToken);
            
            await _graduationProcessBusinessRules.GraduationProcessShouldExistWhenSelected(graduationProcess);

            // Kullanıcının FacultyDeansOffice rolünde staff olup olmadığını kontrol et
            await _graduationProcessBusinessRules.UserShouldBeAuthorizedForFacultyDeansOfficeApproval(graduationProcess!, _httpContextAccessor.HttpContext!.User);

            graduationProcess!.FacultyDeansOfficeApproved = request.IsApproved;
            if (request.IsApproved)
            {
                graduationProcess.FacultyDeansOfficeApprovedDate = DateTime.UtcNow;
            }

            await _graduationProcessRepository.UpdateAsync(graduationProcess);

            ApprovedByFacultyDeansOfficeResponse response = _mapper.Map<ApprovedByFacultyDeansOfficeResponse>(graduationProcess);
            return response;
        }
    }
} 