using Application.Features.TopStudentLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.TopStudentLists.Commands.Update;

public class UpdateTopStudentListCommand : IRequest<UpdatedTopStudentListResponse>
{
    public Guid Id { get; set; }
    public required TopStudentListType TopStudentListType { get; set; }
    public required bool StudentAffairsApproval { get; set; }
    public required Guid StudentAffairsStaffId { get; set; }
    public required bool RectorateApproval { get; set; }
    public required Guid RectorateStaffId { get; set; }
    public required bool SendRectorate { get; set; }

    public class UpdateTopStudentListCommandHandler : IRequestHandler<UpdateTopStudentListCommand, UpdatedTopStudentListResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITopStudentListRepository _topStudentListRepository;
        private readonly TopStudentListBusinessRules _topStudentListBusinessRules;

        public UpdateTopStudentListCommandHandler(IMapper mapper, ITopStudentListRepository topStudentListRepository,
                                         TopStudentListBusinessRules topStudentListBusinessRules)
        {
            _mapper = mapper;
            _topStudentListRepository = topStudentListRepository;
            _topStudentListBusinessRules = topStudentListBusinessRules;
        }

        public async Task<UpdatedTopStudentListResponse> Handle(UpdateTopStudentListCommand request, CancellationToken cancellationToken)
        {
            TopStudentList? topStudentList = await _topStudentListRepository.GetAsync(predicate: tsl => tsl.Id == request.Id, cancellationToken: cancellationToken);
            await _topStudentListBusinessRules.TopStudentListShouldExistWhenSelected(topStudentList);
            topStudentList = _mapper.Map(request, topStudentList);

            await _topStudentListRepository.UpdateAsync(topStudentList!);

            UpdatedTopStudentListResponse response = _mapper.Map<UpdatedTopStudentListResponse>(topStudentList);
            return response;
        }
    }
}