using Application.Features.TopStudentLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;

namespace Application.Features.TopStudentLists.Commands.ApproveStudentAffairs;

public class ApproveStudentAffairsCommand : IRequest<ApprovedStudentAffairsResponse>
{
    public Guid TopStudentListId { get; set; }
    public bool IsApproved { get; set; }

    public class ApproveStudentAffairsCommandHandler : IRequestHandler<ApproveStudentAffairsCommand, ApprovedStudentAffairsResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITopStudentListRepository _topStudentListRepository;
        private readonly TopStudentListBusinessRules _topStudentListBusinessRules;

        public ApproveStudentAffairsCommandHandler(
            IMapper mapper,
            ITopStudentListRepository topStudentListRepository,
            TopStudentListBusinessRules topStudentListBusinessRules)
        {
            _mapper = mapper;
            _topStudentListRepository = topStudentListRepository;
            _topStudentListBusinessRules = topStudentListBusinessRules;
        }

        public async Task<ApprovedStudentAffairsResponse> Handle(ApproveStudentAffairsCommand request, CancellationToken cancellationToken)
        {
            TopStudentList? topStudentList = await _topStudentListRepository.GetAsync(
                predicate: tsl => tsl.Id == request.TopStudentListId,
                cancellationToken: cancellationToken
            );
            await _topStudentListBusinessRules.TopStudentListShouldExistWhenSelected(topStudentList);

            // Student Affairs authorization kontrolü
            await _topStudentListBusinessRules.ValidateStudentAffairsApprovalPrerequisites(topStudentList, cancellationToken);

            // StudentAffairsApproval'ı güncelle
            topStudentList.StudentAffairsApproval = request.IsApproved;

            await _topStudentListRepository.UpdateAsync(topStudentList);

            ApprovedStudentAffairsResponse response = _mapper.Map<ApprovedStudentAffairsResponse>(topStudentList);
            return response;
        }
    }
} 