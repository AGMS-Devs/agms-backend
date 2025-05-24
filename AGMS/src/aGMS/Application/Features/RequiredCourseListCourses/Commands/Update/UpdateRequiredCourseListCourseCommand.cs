using Application.Features.RequiredCourseListCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RequiredCourseListCourses.Commands.Update;

public class UpdateRequiredCourseListCourseCommand : IRequest<UpdatedRequiredCourseListCourseResponse>
{
    public Guid Id { get; set; }
    public required Guid RequiredCourseListId { get; set; }
    public required Guid CourseId { get; set; }

    public class UpdateRequiredCourseListCourseCommandHandler : IRequestHandler<UpdateRequiredCourseListCourseCommand, UpdatedRequiredCourseListCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequiredCourseListCourseRepository _requiredCourseListCourseRepository;
        private readonly RequiredCourseListCourseBusinessRules _requiredCourseListCourseBusinessRules;

        public UpdateRequiredCourseListCourseCommandHandler(IMapper mapper, IRequiredCourseListCourseRepository requiredCourseListCourseRepository,
                                         RequiredCourseListCourseBusinessRules requiredCourseListCourseBusinessRules)
        {
            _mapper = mapper;
            _requiredCourseListCourseRepository = requiredCourseListCourseRepository;
            _requiredCourseListCourseBusinessRules = requiredCourseListCourseBusinessRules;
        }

        public async Task<UpdatedRequiredCourseListCourseResponse> Handle(UpdateRequiredCourseListCourseCommand request, CancellationToken cancellationToken)
        {
            RequiredCourseListCourse? requiredCourseListCourse = await _requiredCourseListCourseRepository.GetAsync(predicate: rclc => rclc.Id == request.Id, cancellationToken: cancellationToken);
            await _requiredCourseListCourseBusinessRules.RequiredCourseListCourseShouldExistWhenSelected(requiredCourseListCourse);
            requiredCourseListCourse = _mapper.Map(request, requiredCourseListCourse);

            await _requiredCourseListCourseRepository.UpdateAsync(requiredCourseListCourse!);

            UpdatedRequiredCourseListCourseResponse response = _mapper.Map<UpdatedRequiredCourseListCourseResponse>(requiredCourseListCourse);
            return response;
        }
    }
}