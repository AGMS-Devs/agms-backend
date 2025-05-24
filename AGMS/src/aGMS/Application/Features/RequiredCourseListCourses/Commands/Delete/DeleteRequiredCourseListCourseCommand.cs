using Application.Features.RequiredCourseListCourses.Constants;
using Application.Features.RequiredCourseListCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RequiredCourseListCourses.Commands.Delete;

public class DeleteRequiredCourseListCourseCommand : IRequest<DeletedRequiredCourseListCourseResponse>
{
    public Guid Id { get; set; }

    public class DeleteRequiredCourseListCourseCommandHandler : IRequestHandler<DeleteRequiredCourseListCourseCommand, DeletedRequiredCourseListCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequiredCourseListCourseRepository _requiredCourseListCourseRepository;
        private readonly RequiredCourseListCourseBusinessRules _requiredCourseListCourseBusinessRules;

        public DeleteRequiredCourseListCourseCommandHandler(IMapper mapper, IRequiredCourseListCourseRepository requiredCourseListCourseRepository,
                                         RequiredCourseListCourseBusinessRules requiredCourseListCourseBusinessRules)
        {
            _mapper = mapper;
            _requiredCourseListCourseRepository = requiredCourseListCourseRepository;
            _requiredCourseListCourseBusinessRules = requiredCourseListCourseBusinessRules;
        }

        public async Task<DeletedRequiredCourseListCourseResponse> Handle(DeleteRequiredCourseListCourseCommand request, CancellationToken cancellationToken)
        {
            RequiredCourseListCourse? requiredCourseListCourse = await _requiredCourseListCourseRepository.GetAsync(predicate: rclc => rclc.Id == request.Id, cancellationToken: cancellationToken);
            await _requiredCourseListCourseBusinessRules.RequiredCourseListCourseShouldExistWhenSelected(requiredCourseListCourse);

            await _requiredCourseListCourseRepository.DeleteAsync(requiredCourseListCourse!);

            DeletedRequiredCourseListCourseResponse response = _mapper.Map<DeletedRequiredCourseListCourseResponse>(requiredCourseListCourse);
            return response;
        }
    }
}