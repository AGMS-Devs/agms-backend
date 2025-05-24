using Application.Features.TakenCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.TakenCourses.Commands.Create;

public class CreateTakenCourseCommand : IRequest<CreatedTakenCourseResponse>
{
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
    public Grade Grade { get; set; }
    public DateTime TakenDate { get; set; }

    public class CreateTakenCourseCommandHandler : IRequestHandler<CreateTakenCourseCommand, CreatedTakenCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITakenCourseRepository _takenCourseRepository;
        private readonly TakenCourseBusinessRules _takenCourseBusinessRules;

        public CreateTakenCourseCommandHandler(IMapper mapper, ITakenCourseRepository takenCourseRepository,
                                         TakenCourseBusinessRules takenCourseBusinessRules)
        {
            _mapper = mapper;
            _takenCourseRepository = takenCourseRepository;
            _takenCourseBusinessRules = takenCourseBusinessRules;
        }

        public async Task<CreatedTakenCourseResponse> Handle(CreateTakenCourseCommand request, CancellationToken cancellationToken)
        {
            await _takenCourseBusinessRules.CourseShouldExistWhenCreatingTakenCourse(request.CourseId, cancellationToken);
            await _takenCourseBusinessRules.StudentShouldExistWhenCreatingTakenCourse(request.StudentId, cancellationToken);
            await _takenCourseBusinessRules.StudentShouldNotHaveTakenCourse(request.StudentId, request.CourseId, cancellationToken);

            TakenCourse takenCourse = _mapper.Map<TakenCourse>(request);

            await _takenCourseRepository.AddAsync(takenCourse);

            CreatedTakenCourseResponse response = _mapper.Map<CreatedTakenCourseResponse>(takenCourse);
            return response;
        }
    }
}