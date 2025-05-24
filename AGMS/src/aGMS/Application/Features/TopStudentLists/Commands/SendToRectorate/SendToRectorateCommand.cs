using Application.Features.TopStudentLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;

namespace Application.Features.TopStudentLists.Commands.SendToRectorate;

public class SendToRectorateCommand : IRequest<SentToRectorateResponse>
{
    public Guid TopStudentListId { get; set; }

    public class SendToRectorateCommandHandler : IRequestHandler<SendToRectorateCommand, SentToRectorateResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITopStudentListRepository _topStudentListRepository;
        private readonly TopStudentListBusinessRules _topStudentListBusinessRules;

        public SendToRectorateCommandHandler(
            IMapper mapper,
            ITopStudentListRepository topStudentListRepository,
            TopStudentListBusinessRules topStudentListBusinessRules)
        {
            _mapper = mapper;
            _topStudentListRepository = topStudentListRepository;
            _topStudentListBusinessRules = topStudentListBusinessRules;
        }

        public async Task<SentToRectorateResponse> Handle(SendToRectorateCommand request, CancellationToken cancellationToken)
        {
            TopStudentList? topStudentList = await _topStudentListRepository.GetAsync(
                predicate: tsl => tsl.Id == request.TopStudentListId,
                cancellationToken: cancellationToken
            );
            await _topStudentListBusinessRules.TopStudentListShouldExistWhenSelected(topStudentList);

            // Send to rectorate prerequisites kontrolü
            await _topStudentListBusinessRules.ValidateSendToRectoratePrerequisites(topStudentList, cancellationToken);

            // SendRectorate'i true yap
            topStudentList.SendRectorate = true;

            await _topStudentListRepository.UpdateAsync(topStudentList);

            SentToRectorateResponse response = _mapper.Map<SentToRectorateResponse>(topStudentList);
            return response;
        }
    }
} 