using Application.Features.RequiredCourseListCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RequiredCourseListCourses.Queries.GetById;

public class GetByIdRequiredCourseListCourseQuery : IRequest<GetByIdRequiredCourseListCourseResponse>
{
    public Guid Id { get; set; }

    public class GetByIdRequiredCourseListCourseQueryHandler : IRequestHandler<GetByIdRequiredCourseListCourseQuery, GetByIdRequiredCourseListCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequiredCourseListCourseRepository _requiredCourseListCourseRepository;
        private readonly RequiredCourseListCourseBusinessRules _requiredCourseListCourseBusinessRules;

        public GetByIdRequiredCourseListCourseQueryHandler(IMapper mapper, IRequiredCourseListCourseRepository requiredCourseListCourseRepository, RequiredCourseListCourseBusinessRules requiredCourseListCourseBusinessRules)
        {
            _mapper = mapper;
            _requiredCourseListCourseRepository = requiredCourseListCourseRepository;
            _requiredCourseListCourseBusinessRules = requiredCourseListCourseBusinessRules;
        }

        public async Task<GetByIdRequiredCourseListCourseResponse> Handle(GetByIdRequiredCourseListCourseQuery request, CancellationToken cancellationToken)
        {
            RequiredCourseListCourse? requiredCourseListCourse = await _requiredCourseListCourseRepository.GetAsync(predicate: rclc => rclc.Id == request.Id, cancellationToken: cancellationToken);
            await _requiredCourseListCourseBusinessRules.RequiredCourseListCourseShouldExistWhenSelected(requiredCourseListCourse);

            GetByIdRequiredCourseListCourseResponse response = _mapper.Map<GetByIdRequiredCourseListCourseResponse>(requiredCourseListCourse);
            return response;
        }
    }
}