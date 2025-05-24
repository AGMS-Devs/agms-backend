using Application.Features.TakenCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.TakenCourses.Queries.GetByStudent;

public class GetTakenCoursesByStudentQuery : IRequest<GetTakenCoursesByStudentResponse>
{
    public Guid StudentId { get; set; }

    public class GetTakenCoursesByStudentQueryHandler : IRequestHandler<GetTakenCoursesByStudentQuery, GetTakenCoursesByStudentResponse>
    {
        private readonly ITakenCourseRepository _takenCourseRepository;
        private readonly IMapper _mapper;
        private readonly TakenCourseBusinessRules _takenCourseBusinessRules;

        public GetTakenCoursesByStudentQueryHandler(
            ITakenCourseRepository takenCourseRepository,
            IMapper mapper,
            TakenCourseBusinessRules takenCourseBusinessRules)
        {
            _takenCourseRepository = takenCourseRepository;
            _mapper = mapper;
            _takenCourseBusinessRules = takenCourseBusinessRules;
        }

        public async Task<GetTakenCoursesByStudentResponse> Handle(GetTakenCoursesByStudentQuery request, CancellationToken cancellationToken)
        {
            var takenCourses = await _takenCourseRepository.GetListAsync(
                predicate: tc => tc.StudentId == request.StudentId,
                include: query => query.Include(tc => tc.Course),
                orderBy: query => query.OrderByDescending(tc => tc.TakenDate),
                size: int.MaxValue,
                cancellationToken: cancellationToken
            );

            await _takenCourseBusinessRules.StudentShouldHaveAtLeastOneTakenCourse(takenCourses.Items);

            return new GetTakenCoursesByStudentResponse
            {
                StudentId = request.StudentId,
                TakenCourses = _mapper.Map<List<TakenCourseDto>>(takenCourses.Items)
            };
        }
    }
} 