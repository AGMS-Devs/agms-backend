using Application.Features.RequiredCourseListCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RequiredCourseListCourses.Commands.Create;

public class CreateRequiredCourseListCourseCommand : IRequest<CreatedRequiredCourseListCourseResponse>
{
    public required Guid RequiredCourseListId { get; set; }
    public required Guid CourseId { get; set; }

    public class CreateRequiredCourseListCourseCommandHandler : IRequestHandler<CreateRequiredCourseListCourseCommand, CreatedRequiredCourseListCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequiredCourseListCourseRepository _requiredCourseListCourseRepository;
        private readonly RequiredCourseListCourseBusinessRules _requiredCourseListCourseBusinessRules;

        public CreateRequiredCourseListCourseCommandHandler(IMapper mapper, IRequiredCourseListCourseRepository requiredCourseListCourseRepository,
                                         RequiredCourseListCourseBusinessRules requiredCourseListCourseBusinessRules)
        {
            _mapper = mapper;
            _requiredCourseListCourseRepository = requiredCourseListCourseRepository;
            _requiredCourseListCourseBusinessRules = requiredCourseListCourseBusinessRules;
        }

        public async Task<CreatedRequiredCourseListCourseResponse> Handle(CreateRequiredCourseListCourseCommand request, CancellationToken cancellationToken)
        {
            RequiredCourseListCourse requiredCourseListCourse = _mapper.Map<RequiredCourseListCourse>(request);

            await _requiredCourseListCourseRepository.AddAsync(requiredCourseListCourse);

            CreatedRequiredCourseListCourseResponse response = _mapper.Map<CreatedRequiredCourseListCourseResponse>(requiredCourseListCourse);
            return response;
        }
    }
}