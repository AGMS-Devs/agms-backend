using Application.Features.TopStudentLists.Constants;
using Application.Features.TopStudentLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TopStudentLists.Commands.Delete;

public class DeleteTopStudentListCommand : IRequest<DeletedTopStudentListResponse>
{
    public Guid Id { get; set; }

    public class DeleteTopStudentListCommandHandler : IRequestHandler<DeleteTopStudentListCommand, DeletedTopStudentListResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITopStudentListRepository _topStudentListRepository;
        private readonly TopStudentListBusinessRules _topStudentListBusinessRules;

        public DeleteTopStudentListCommandHandler(IMapper mapper, ITopStudentListRepository topStudentListRepository,
                                         TopStudentListBusinessRules topStudentListBusinessRules)
        {
            _mapper = mapper;
            _topStudentListRepository = topStudentListRepository;
            _topStudentListBusinessRules = topStudentListBusinessRules;
        }

        public async Task<DeletedTopStudentListResponse> Handle(DeleteTopStudentListCommand request, CancellationToken cancellationToken)
        {
            TopStudentList? topStudentList = await _topStudentListRepository.GetAsync(predicate: tsl => tsl.Id == request.Id, cancellationToken: cancellationToken);
            await _topStudentListBusinessRules.TopStudentListShouldExistWhenSelected(topStudentList);

            await _topStudentListRepository.DeleteAsync(topStudentList!);

            DeletedTopStudentListResponse response = _mapper.Map<DeletedTopStudentListResponse>(topStudentList);
            return response;
        }
    }
}