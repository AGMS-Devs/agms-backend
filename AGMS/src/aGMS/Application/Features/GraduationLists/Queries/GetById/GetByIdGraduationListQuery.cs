using Application.Features.GraduationLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GraduationLists.Queries.GetById;

public class GetByIdGraduationListQuery : IRequest<GetByIdGraduationListResponse>
{
    public Guid Id { get; set; }

    public class GetByIdGraduationListQueryHandler : IRequestHandler<GetByIdGraduationListQuery, GetByIdGraduationListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationListRepository _graduationListRepository;
        private readonly GraduationListBusinessRules _graduationListBusinessRules;

        public GetByIdGraduationListQueryHandler(IMapper mapper, IGraduationListRepository graduationListRepository, GraduationListBusinessRules graduationListBusinessRules)
        {
            _mapper = mapper;
            _graduationListRepository = graduationListRepository;
            _graduationListBusinessRules = graduationListBusinessRules;
        }

        public async Task<GetByIdGraduationListResponse> Handle(GetByIdGraduationListQuery request, CancellationToken cancellationToken)
        {
            GraduationList? graduationList = await _graduationListRepository.GetAsync(predicate: gl => gl.Id == request.Id, cancellationToken: cancellationToken);
            await _graduationListBusinessRules.GraduationListShouldExistWhenSelected(graduationList);

            GetByIdGraduationListResponse response = _mapper.Map<GetByIdGraduationListResponse>(graduationList);
            return response;
        }
    }
}