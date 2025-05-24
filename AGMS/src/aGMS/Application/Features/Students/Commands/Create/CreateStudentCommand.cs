using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Students.Commands.Create;

public class CreateStudentCommand : IRequest<CreatedStudentResponse>
{
    public Guid UserId { get; set; }
    public string StudentNumber { get; set; }
    public Guid DepartmentId { get; set; }
    public DateTime EnrollDate { get; set; }
    public StudentStatus StudentStatus { get; set; }
    public GraduationStatus GraduationStatus { get; set; }
    public Guid AssignedAdvisorId { get; set; }
    public Guid RequiredCourseListId { get; set; }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreatedStudentResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IAdvisorRepository _advisorRepository;
        private readonly IRequiredCourseListRepository _requiredCourseListRepository;
        private readonly IMapper _mapper;
        private readonly StudentBusinessRules _studentBusinessRules;

        public CreateStudentCommandHandler(
            IStudentRepository studentRepository,
            IUserRepository userRepository,
            IDepartmentRepository departmentRepository,
            IAdvisorRepository advisorRepository,
            IRequiredCourseListRepository requiredCourseListRepository,
            IMapper mapper,
            StudentBusinessRules studentBusinessRules
        )
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
            _advisorRepository = advisorRepository;
            _requiredCourseListRepository = requiredCourseListRepository;
            _mapper = mapper;
            _studentBusinessRules = studentBusinessRules;
        }

        public async Task<CreatedStudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            // Kullanıcının var olduğunu ve öğrenci tipinde olduğunu kontrol et
            var user = await _userRepository.GetAsync(
                predicate: u => u.Id == request.UserId && u.UserType == UserType.Student,
                cancellationToken: cancellationToken
            );

            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı veya öğrenci tipinde değil.");
            }

            // Bölümün var olduğunu kontrol et
            var department = await _departmentRepository.GetAsync(
                predicate: d => d.Id == request.DepartmentId,
                cancellationToken: cancellationToken
            );

            if (department == null)
            {
                throw new Exception("Bölüm bulunamadı.");
            }

            // Danışmanın var olduğunu kontrol et (eğer atanmışsa)
            if (request.AssignedAdvisorId != Guid.Empty)
            {
                var advisor = await _advisorRepository.GetAsync(
                    predicate: a => a.Id == request.AssignedAdvisorId,
                    cancellationToken: cancellationToken
                );

                if (advisor == null)
                {
                    throw new Exception("Danışman bulunamadı.");
                }
            }

            // Öğrenci numarasının benzersiz olduğunu kontrol et
            await _studentBusinessRules.StudentNumberShouldBeUnique(request.StudentNumber);

                      // Öğrenci için boş bir RequiredCourseList oluştur
            RequiredCourseList requiredCourseList = new()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow
            };
           
            Student student = new()
            {
                Id = request.UserId, // TPT için User ID'yi kullan
                StudentNumber = request.StudentNumber,
                DepartmentId = request.DepartmentId,
                EnrollDate = request.EnrollDate,
                StudentStatus = request.StudentStatus,
                GraduationStatus = request.GraduationStatus,
                AssignedAdvisorId = request.AssignedAdvisorId,
                RequiredCourseListId = requiredCourseList.Id,
                CreatedDate = DateTime.UtcNow
            };

            Student createdStudent = await _studentRepository.AddAsync(student);

  

            await _requiredCourseListRepository.AddAsync(requiredCourseList);

            CreatedStudentResponse response = _mapper.Map<CreatedStudentResponse>(createdStudent);
            return response;
        }
    }
}