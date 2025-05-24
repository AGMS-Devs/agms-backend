using Application.Features.TakenCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TakenCourses.Queries.GetById;

public class GetByIdTakenCourseQuery : IRequest<GetByIdTakenCourseResponse>
{
    public Guid Id { get; set; }

    public class GetByIdTakenCourseQueryHandler : IRequestHandler<GetByIdTakenCourseQuery, GetByIdTakenCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITakenCourseRepository _takenCourseRepository;
        private readonly TakenCourseBusinessRules _takenCourseBusinessRules;

        public GetByIdTakenCourseQueryHandler(IMapper mapper, ITakenCourseRepository takenCourseRepository, TakenCourseBusinessRules takenCourseBusinessRules)
        {
            _mapper = mapper;
            _takenCourseRepository = takenCourseRepository;
            _takenCourseBusinessRules = takenCourseBusinessRules;
        }

        public async Task<GetByIdTakenCourseResponse> Handle(GetByIdTakenCourseQuery request, CancellationToken cancellationToken)
        {
            TakenCourse? takenCourse = await _takenCourseRepository.GetAsync(predicate: tc => tc.Id == request.Id, cancellationToken: cancellationToken);
            await _takenCourseBusinessRules.TakenCourseShouldExistWhenSelected(takenCourse);

            GetByIdTakenCourseResponse response = _mapper.Map<GetByIdTakenCourseResponse>(takenCourse);
            return response;
        }
    }
}