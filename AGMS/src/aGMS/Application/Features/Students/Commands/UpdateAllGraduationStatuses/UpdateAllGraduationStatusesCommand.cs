using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Students.Commands.UpdateAllGraduationStatuses;

public class UpdateAllGraduationStatusesCommand : IRequest<UpdatedAllGraduationStatusesResponse>
{
    public class UpdateAllGraduationStatusesCommandHandler : IRequestHandler<UpdateAllGraduationStatusesCommand, UpdatedAllGraduationStatusesResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly IGraduationProcessRepository _graduationProcessRepository;
        private readonly StudentBusinessRules _studentBusinessRules;

        public UpdateAllGraduationStatusesCommandHandler(
            IMapper mapper, 
            IStudentRepository studentRepository,
            IGraduationProcessRepository graduationProcessRepository,
            StudentBusinessRules studentBusinessRules)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _graduationProcessRepository = graduationProcessRepository;
            _studentBusinessRules = studentBusinessRules;
        }

        public async Task<UpdatedAllGraduationStatusesResponse> Handle(UpdateAllGraduationStatusesCommand request, CancellationToken cancellationToken)
        {
            // Tüm onayları (AdvisorApproved, DepartmentSecretaryApproved, FacultyDeansOfficeApproved, StudentAffairsApproved) true olan graduation process'leri bul
            var fullyApprovedGraduationProcesses = await _graduationProcessRepository.GetListAsync(
                predicate: gp => gp.AdvisorApproved == true && 
                               gp.DepartmentSecretaryApproved == true && 
                               gp.FacultyDeansOfficeApproved == true && 
                               gp.StudentAffairsApproved == true,
                size: int.MaxValue,
                cancellationToken: cancellationToken
            );

            var updatedCount = 0;
            var failedCount = 0;
            var updatedStudentIds = new List<Guid>();

            foreach (var graduationProcess in fullyApprovedGraduationProcesses.Items)
            {
                try
                {
                    // İlgili öğrenciyi bul
                    var student = await _studentRepository.GetAsync(
                        predicate: s => s.Id == graduationProcess.StudentId,
                        cancellationToken: cancellationToken
                    );

                    if (student != null)
                    {
                        // GraduationStatus'u Approved olarak güncelle
                        student.GraduationStatus = GraduationStatus.Approved;
                        
                        await _studentRepository.UpdateAsync(student);
                        
                        updatedCount++;
                        updatedStudentIds.Add(student.Id);
                    }
                    else
                    {
                        failedCount++;
                        Console.WriteLine($"HATA: StudentId {graduationProcess.StudentId} bulunamadı");
                    }
                }
                catch (Exception ex)
                {
                    failedCount++;
                    Console.WriteLine($"HATA: StudentId {graduationProcess.StudentId} için GraduationStatus güncellenirken hata: {ex.Message}");
                }
            }

            var response = new UpdatedAllGraduationStatusesResponse
            {
                TotalProcessed = fullyApprovedGraduationProcesses.Items.Count,
                SuccessfullyUpdated = updatedCount,
                Failed = failedCount,
                UpdatedStudentIds = updatedStudentIds,
                UpdatedDate = DateTime.Now
            };

            return response;
        }
    }
} 