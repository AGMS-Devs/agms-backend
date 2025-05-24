using Application.Features.RequiredCourseLists.Constants;
using Application.Features.RequiredCourseLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RequiredCourseLists.Commands.Delete;

public class DeleteRequiredCourseListCommand : IRequest<DeletedRequiredCourseListResponse>
{
    public Guid Id { get; set; }

    public class DeleteRequiredCourseListCommandHandler : IRequestHandler<DeleteRequiredCourseListCommand, DeletedRequiredCourseListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequiredCourseListRepository _requiredCourseListRepository;
        private readonly RequiredCourseListBusinessRules _requiredCourseListBusinessRules;

        public DeleteRequiredCourseListCommandHandler(IMapper mapper, IRequiredCourseListRepository requiredCourseListRepository,
                                         RequiredCourseListBusinessRules requiredCourseListBusinessRules)
        {
            _mapper = mapper;
            _requiredCourseListRepository = requiredCourseListRepository;
            _requiredCourseListBusinessRules = requiredCourseListBusinessRules;
        }

        public async Task<DeletedRequiredCourseListResponse> Handle(DeleteRequiredCourseListCommand request, CancellationToken cancellationToken)
        {
            RequiredCourseList? requiredCourseList = await _requiredCourseListRepository.GetAsync(predicate: rcl => rcl.Id == request.Id, cancellationToken: cancellationToken);
            await _requiredCourseListBusinessRules.RequiredCourseListShouldExistWhenSelected(requiredCourseList);

            await _requiredCourseListRepository.DeleteAsync(requiredCourseList!);

            DeletedRequiredCourseListResponse response = _mapper.Map<DeletedRequiredCourseListResponse>(requiredCourseList);
            return response;
        }
    }
}