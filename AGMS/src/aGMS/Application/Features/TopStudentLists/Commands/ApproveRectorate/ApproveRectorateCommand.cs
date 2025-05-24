using Application.Features.TopStudentLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;

namespace Application.Features.TopStudentLists.Commands.ApproveRectorate;

public class ApproveRectorateCommand : IRequest<ApprovedRectorateResponse>
{
    public Guid TopStudentListId { get; set; }
    public bool IsApproved { get; set; }

    public class ApproveRectorateCommandHandler : IRequestHandler<ApproveRectorateCommand, ApprovedRectorateResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITopStudentListRepository _topStudentListRepository;
        private readonly TopStudentListBusinessRules _topStudentListBusinessRules;

        public ApproveRectorateCommandHandler(
            IMapper mapper,
            ITopStudentListRepository topStudentListRepository,
            TopStudentListBusinessRules topStudentListBusinessRules)
        {
            _mapper = mapper;
            _topStudentListRepository = topStudentListRepository;
            _topStudentListBusinessRules = topStudentListBusinessRules;
        }

        public async Task<ApprovedRectorateResponse> Handle(ApproveRectorateCommand request, CancellationToken cancellationToken)
        {
            TopStudentList? topStudentList = await _topStudentListRepository.GetAsync(
                predicate: tsl => tsl.Id == request.TopStudentListId,
                cancellationToken: cancellationToken
            );
            await _topStudentListBusinessRules.TopStudentListShouldExistWhenSelected(topStudentList);

            // Rectorate authorization kontrolü
            await _topStudentListBusinessRules.ValidateRectorateApprovalPrerequisites(topStudentList, cancellationToken);

            // RectorateApproval'ı güncelle
            topStudentList.RectorateApproval = request.IsApproved;

            await _topStudentListRepository.UpdateAsync(topStudentList);

            ApprovedRectorateResponse response = _mapper.Map<ApprovedRectorateResponse>(topStudentList);
            return response;
        }
    }
} 