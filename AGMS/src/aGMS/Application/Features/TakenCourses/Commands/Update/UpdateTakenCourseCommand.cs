using Application.Features.TakenCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.TakenCourses.Commands.Update;

public class UpdateTakenCourseCommand : IRequest<UpdatedTakenCourseResponse>
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
    public Grade Grade { get; set; }
    public DateTime TakenDate { get; set; }

    public class UpdateTakenCourseCommandHandler : IRequestHandler<UpdateTakenCourseCommand, UpdatedTakenCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITakenCourseRepository _takenCourseRepository;
        private readonly TakenCourseBusinessRules _takenCourseBusinessRules;

        public UpdateTakenCourseCommandHandler(IMapper mapper, ITakenCourseRepository takenCourseRepository,
                                         TakenCourseBusinessRules takenCourseBusinessRules)
        {
            _mapper = mapper;
            _takenCourseRepository = takenCourseRepository;
            _takenCourseBusinessRules = takenCourseBusinessRules;
        }

        public async Task<UpdatedTakenCourseResponse> Handle(UpdateTakenCourseCommand request, CancellationToken cancellationToken)
        {
            TakenCourse? takenCourse = await _takenCourseRepository.GetAsync(predicate: tc => tc.Id == request.Id, cancellationToken: cancellationToken);
            await _takenCourseBusinessRules.TakenCourseShouldExistWhenSelected(takenCourse);

            // Course ve Student varlığını kontrol et
            await _takenCourseBusinessRules.CourseShouldExistWhenCreatingTakenCourse(request.CourseId, cancellationToken);
            await _takenCourseBusinessRules.StudentShouldExistWhenCreatingTakenCourse(request.StudentId, cancellationToken);

            // Eğer Course veya Student değiştiyse, öğrencinin bu dersi daha önce almadığından emin ol
            if (takenCourse!.CourseId != request.CourseId || takenCourse.StudentId != request.StudentId)
            {
                await _takenCourseBusinessRules.StudentShouldNotHaveTakenCourse(request.StudentId, request.CourseId, cancellationToken);
            }

            takenCourse = _mapper.Map(request, takenCourse);

            await _takenCourseRepository.UpdateAsync(takenCourse!);

            UpdatedTakenCourseResponse response = _mapper.Map<UpdatedTakenCourseResponse>(takenCourse);
            return response;
        }
    }
}