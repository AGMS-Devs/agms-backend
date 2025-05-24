using Application.Features.GraduationLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GraduationLists.Commands.Create;

public class CreateGraduationListCommand : IRequest<CreatedGraduationListResponse>
{
    public string GraduationListNumber { get; set; }
    public Guid AdvisorId { get; set; }
    public Advisor Advisor { get; set; }

    public class CreateGraduationListCommandHandler : IRequestHandler<CreateGraduationListCommand, CreatedGraduationListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationListRepository _graduationListRepository;
        private readonly GraduationListBusinessRules _graduationListBusinessRules;

        public CreateGraduationListCommandHandler(IMapper mapper, IGraduationListRepository graduationListRepository,
                                         GraduationListBusinessRules graduationListBusinessRules)
        {
            _mapper = mapper;
            _graduationListRepository = graduationListRepository;
            _graduationListBusinessRules = graduationListBusinessRules;
        }

        public async Task<CreatedGraduationListResponse> Handle(CreateGraduationListCommand request, CancellationToken cancellationToken)
        {
            GraduationList graduationList = _mapper.Map<GraduationList>(request);

            await _graduationListRepository.AddAsync(graduationList);

            CreatedGraduationListResponse response = _mapper.Map<CreatedGraduationListResponse>(graduationList);
            return response;
        }
    }
}