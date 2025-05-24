using Application.Services.Repositories;
using Application.Features.TopStudentLists.Queries.GetById;
using Application.Features.TopStudentLists.Rules;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Features.TopStudentLists.Queries.GetList;

public class GetListTopStudentListQuery : IRequest<GetListResponse<GetListTopStudentListListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTopStudentListQueryHandler : IRequestHandler<GetListTopStudentListQuery, GetListResponse<GetListTopStudentListListItemDto>>
    {
        private readonly ITopStudentListRepository _topStudentListRepository;
        private readonly ITranscriptRepository _transcriptRepository;
        private readonly TopStudentListBusinessRules _topStudentListBusinessRules;
        private readonly IMapper _mapper;

        public GetListTopStudentListQueryHandler(
            ITopStudentListRepository topStudentListRepository,
            ITranscriptRepository transcriptRepository,
            TopStudentListBusinessRules topStudentListBusinessRules,
            IMapper mapper)
        {
            _topStudentListRepository = topStudentListRepository;
            _transcriptRepository = transcriptRepository;
            _topStudentListBusinessRules = topStudentListBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTopStudentListListItemDto>> Handle(GetListTopStudentListQuery request, CancellationToken cancellationToken)
        {
            // Current user'ın staff bilgilerini al
            var staff = await _topStudentListBusinessRules.GetCurrentStaff(cancellationToken);
            var currentUserId = await _topStudentListBusinessRules.GetCurrentUserId();

            // Predicate'i staff role'üne göre ayarla
            Expression<Func<TopStudentList, bool>> predicate = staff.StaffRole switch
            {
                Domain.Enums.StaffRole.StudentAffairs => tsl => tsl.StudentAffairsStaffId == currentUserId,
                Domain.Enums.StaffRole.Rectorate => tsl => tsl.RectorateStaffId == currentUserId && tsl.SendRectorate == true,
                _ => throw new NArchitecture.Core.CrossCuttingConcerns.Exception.Types.BusinessException("Invalid staff role for accessing top student lists")
            };

            IPaginate<TopStudentList> topStudentLists = await _topStudentListRepository.GetListAsync(
                predicate: predicate,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: query => query
                    .Include(tsl => tsl.Students)
                        .ThenInclude(s => s.User)
                    .Include(tsl => tsl.Students)
                        .ThenInclude(s => s.Department)
                            .ThenInclude(d => d.FacultyDeansOffice),
                cancellationToken: cancellationToken
            );

            var response = new GetListResponse<GetListTopStudentListListItemDto>
            {
                Items = new List<GetListTopStudentListListItemDto>(),
                HasNext = topStudentLists.HasNext,
                HasPrevious = topStudentLists.HasPrevious,
                Index = topStudentLists.Index,
                Size = topStudentLists.Size,
                Count = topStudentLists.Count,
                Pages = topStudentLists.Pages
            };

            foreach (var topStudentList in topStudentLists.Items)
            {
                var item = _mapper.Map<GetListTopStudentListListItemDto>(topStudentList);
                item.Students = new List<TopStudentDto>();
                item.StudentCount = topStudentList.Students.Count;

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
                        item.Students.Add(new TopStudentDto
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
                item.Students = item.Students.OrderByDescending(s => s.TranscriptGpa).ToList();
                
                response.Items.Add(item);
            }

            return response;
        }
    }
}