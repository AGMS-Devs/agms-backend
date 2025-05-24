using Application.Features.TakenCourses.Constants;
using Application.Features.TakenCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TakenCourses.Commands.Delete;

public class DeleteTakenCourseCommand : IRequest<DeletedTakenCourseResponse>
{
    public Guid Id { get; set; }

    public class DeleteTakenCourseCommandHandler : IRequestHandler<DeleteTakenCourseCommand, DeletedTakenCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITakenCourseRepository _takenCourseRepository;
        private readonly TakenCourseBusinessRules _takenCourseBusinessRules;

        public DeleteTakenCourseCommandHandler(IMapper mapper, ITakenCourseRepository takenCourseRepository,
                                         TakenCourseBusinessRules takenCourseBusinessRules)
        {
            _mapper = mapper;
            _takenCourseRepository = takenCourseRepository;
            _takenCourseBusinessRules = takenCourseBusinessRules;
        }

        public async Task<DeletedTakenCourseResponse> Handle(DeleteTakenCourseCommand request, CancellationToken cancellationToken)
        {
            TakenCourse? takenCourse = await _takenCourseRepository.GetAsync(predicate: tc => tc.Id == request.Id, cancellationToken: cancellationToken);
            await _takenCourseBusinessRules.TakenCourseShouldExistWhenSelected(takenCourse);

            await _takenCourseRepository.DeleteAsync(takenCourse!);

            DeletedTakenCourseResponse response = _mapper.Map<DeletedTakenCourseResponse>(takenCourse);
            return response;
        }
    }
}