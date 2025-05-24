using Application.Features.TopStudentLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.TopStudentLists.Commands.Create;

public class CreateTopStudentListCommand : IRequest<CreatedTopStudentListResponse>
{
    public required TopStudentListType TopStudentListType { get; set; }
    public required Guid StudentAffairsStaffId { get; set; }
    public required Guid RectorateStaffId { get; set; }
    
    // Type'a göre hangi filtre uygulanacağını belirlemek için
    public Guid? DepartmentId { get; set; } // Department seçilirse
    public Guid? FacultyId { get; set; }    // Faculty seçilirse
    // University seçilirse hem DepartmentId hem FacultyId null olur

    public class CreateTopStudentListCommandHandler : IRequestHandler<CreateTopStudentListCommand, CreatedTopStudentListResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITopStudentListRepository _topStudentListRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITranscriptRepository _transcriptRepository;
        private readonly TopStudentListBusinessRules _topStudentListBusinessRules;

        public CreateTopStudentListCommandHandler(
            IMapper mapper, 
            ITopStudentListRepository topStudentListRepository,
            IStudentRepository studentRepository,
            ITranscriptRepository transcriptRepository,
            TopStudentListBusinessRules topStudentListBusinessRules)
        {
            _mapper = mapper;
            _topStudentListRepository = topStudentListRepository;
            _studentRepository = studentRepository;
            _transcriptRepository = transcriptRepository;
            _topStudentListBusinessRules = topStudentListBusinessRules;
        }

        public async Task<CreatedTopStudentListResponse> Handle(CreateTopStudentListCommand request, CancellationToken cancellationToken)
        {
            // Type'a göre gerekli parametrelerin kontrolü
            switch (request.TopStudentListType)
            {
                case TopStudentListType.Department:
                    if (!request.DepartmentId.HasValue)
                        throw new ArgumentException("DepartmentId is required when TopStudentListType is Department.");
                    break;

                case TopStudentListType.Faculty:
                    if (!request.FacultyId.HasValue)
                        throw new ArgumentException("FacultyId is required when TopStudentListType is Faculty.");
                    break;

                case TopStudentListType.University:
                    // University için ek parametre gerekmez
                    break;
            }

            // TopStudentList'i oluştur
            TopStudentList topStudentList = new TopStudentList
            {
                TopStudentListType = request.TopStudentListType,
                StudentAffairsApproval = false, // Başlangıçta false
                StudentAffairsStaffId = request.StudentAffairsStaffId,
                RectorateApproval = false, // Başlangıçta false
                RectorateStaffId = request.RectorateStaffId,
                SendRectorate = false, // Başlangıçta false
                Students = new HashSet<Student>()
            };

            // Type'a göre uygun öğrencileri getir ve GPA'ya göre sırala
            var eligibleStudents = await GetEligibleStudentsSortedByGpa(request, cancellationToken);
            
            // Öğrencileri TopStudentList'e ekle
            foreach (var student in eligibleStudents)
            {
                topStudentList.Students.Add(student);
            }

            await _topStudentListRepository.AddAsync(topStudentList);

            CreatedTopStudentListResponse response = _mapper.Map<CreatedTopStudentListResponse>(topStudentList);
            response.StudentCount = eligibleStudents.Count;
            return response;
        }

        private async Task<List<Student>> GetEligibleStudentsSortedByGpa(CreateTopStudentListCommand request, CancellationToken cancellationToken)
        {
            // Type'a göre filtreleme uygula ve graduation status'ü Approved olan öğrencileri al
            var students = await _studentRepository.GetListAsync(
                predicate: s => s.GraduationStatus == GraduationStatus.Approved,
                include: query => query
                    .Include(s => s.User)
                    .Include(s => s.Department)
                        .ThenInclude(d => d.FacultyDeansOffice),
                size: int.MaxValue, // Tüm kayıtları getir
                index: 0,
                cancellationToken: cancellationToken
            );

            var filteredStudents = students.Items.AsQueryable();

            // Type'a göre filtreleme uygula
            switch (request.TopStudentListType)
            {
                case TopStudentListType.Department:
                    if (request.DepartmentId.HasValue)
                    {
                        filteredStudents = filteredStudents.Where(s => s.DepartmentId == request.DepartmentId.Value);
                    }
                    break;

                case TopStudentListType.Faculty:
                    if (request.FacultyId.HasValue)
                    {
                        filteredStudents = filteredStudents.Where(s => s.Department.FacultyId == request.FacultyId.Value);
                    }
                    break;

                case TopStudentListType.University:
                    // Üniversite için herhangi bir ek filtre yok, sadece GraduationStatus.Approved
                    break;
            }

            // Her öğrenci için transcript'ini al ve GPA'ya göre sırala
            var studentsWithTranscripts = new List<(Student Student, decimal Gpa)>();

            foreach (var student in filteredStudents)
            {
                var transcript = await _transcriptRepository.GetAsync(
                    predicate: t => t.StudentId == student.Id,
                    enableTracking: false,
                    cancellationToken: cancellationToken
                );

                if (transcript != null)
                {
                    studentsWithTranscripts.Add((student, transcript.TranscriptGpa));
                }
            }

            // GPA'ya göre en iyiden en kötüye sırala
            var sortedStudents = studentsWithTranscripts
                .OrderByDescending(x => x.Gpa)
                .Select(x => x.Student)
                .ToList();

            return sortedStudents;
        }
    }
}