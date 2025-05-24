using Application.Features.TopStudentLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;

namespace Application.Features.TopStudentLists.Queries.GetById;

public class GetByIdTopStudentListQuery : IRequest<GetByIdTopStudentListResponse>
{
    public Guid Id { get; set; }

    public class GetByIdTopStudentListQueryHandler : IRequestHandler<GetByIdTopStudentListQuery, GetByIdTopStudentListResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITopStudentListRepository _topStudentListRepository;
        private readonly ITranscriptRepository _transcriptRepository;
        private readonly TopStudentListBusinessRules _topStudentListBusinessRules;

        public GetByIdTopStudentListQueryHandler(
            IMapper mapper, 
            ITopStudentListRepository topStudentListRepository,
            ITranscriptRepository transcriptRepository,
            TopStudentListBusinessRules topStudentListBusinessRules)
        {
            _mapper = mapper;
            _topStudentListRepository = topStudentListRepository;
            _transcriptRepository = transcriptRepository;
            _topStudentListBusinessRules = topStudentListBusinessRules;
        }

        public async Task<GetByIdTopStudentListResponse> Handle(GetByIdTopStudentListQuery request, CancellationToken cancellationToken)
        {
            TopStudentList? topStudentList = await _topStudentListRepository.GetAsync(
                predicate: tsl => tsl.Id == request.Id,
                include: query => query
                    .Include(tsl => tsl.Students)
                        .ThenInclude(s => s.User)
                    .Include(tsl => tsl.Students)
                        .ThenInclude(s => s.Department)
                            .ThenInclude(d => d.FacultyDeansOffice),
                cancellationToken: cancellationToken);
            
            await _topStudentListBusinessRules.TopStudentListShouldExistWhenSelected(topStudentList);

            // Access kontrolü
            var hasAccess = await _topStudentListBusinessRules.CanUserAccessTopStudentList(topStudentList, cancellationToken);
            if (!hasAccess)
                throw new NArchitecture.Core.CrossCuttingConcerns.Exception.Types.BusinessException("You don't have access to this top student list");

            GetByIdTopStudentListResponse response = _mapper.Map<GetByIdTopStudentListResponse>(topStudentList);
            
            // Öğrenci detaylarını manuel olarak ekle
            response.Students = new List<TopStudentDto>();
            response.StudentCount = topStudentList.Students.Count;

            foreach (var student in topStudentList.Students)
            {
                // Her öğrenci için transcript'ini al
                var transcript = await _transcriptRepository.GetAsync(
                    predicate: t => t.StudentId == student.Id,
                    enableTracking: false,
                    cancellationToken: cancellationToken
                );

                if (transcript != null)
                {
                    response.Students.Add(new TopStudentDto
                    {
                        StudentId = student.Id,
                        StudentNumber = student.StudentNumber,
                        StudentName = student.User.Name,
                        StudentSurname = student.User.Surname,
                        DepartmentName = student.Department.DepartmentName,
                        FacultyName = student.Department.FacultyDeansOffice.FacultyName,
                        TranscriptGpa = transcript.TranscriptGpa
                    });
                }
            }

            // GPA'ya göre sırala (en yüksek GPA ilk sırada)
            response.Students = response.Students.OrderByDescending(s => s.TranscriptGpa).ToList();

            return response;
        }
    }
}