using Application.Features.Courses.Constants;
using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Courses.Commands.Delete;

public class DeleteCourseCommand : IRequest<DeletedCourseResponse>
{
    public Guid Id { get; set; }

    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, DeletedCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly CourseBusinessRules _courseBusinessRules;

        public DeleteCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository,
                                         CourseBusinessRules courseBusinessRules)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _courseBusinessRules = courseBusinessRules;
        }

        public async Task<DeletedCourseResponse> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _courseBusinessRules.CourseShouldExistWhenSelected(course);
            
            // Ders silinmeden önce kullanımda olup olmadığını kontrol et
            await _courseBusinessRules.CourseShouldNotBeUsedWhenDeleting(course!);

            await _courseRepository.DeleteAsync(course!);

            DeletedCourseResponse response = _mapper.Map<DeletedCourseResponse>(course);
            return response;
        }
    }
}