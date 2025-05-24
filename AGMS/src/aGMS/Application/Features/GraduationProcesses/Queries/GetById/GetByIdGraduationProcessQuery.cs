using Application.Features.GraduationProcesses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GraduationProcesses.Queries.GetById;

public class GetByIdGraduationProcessQuery : IRequest<GetByIdGraduationProcessResponse>
{
    public Guid? Id { get; set; }
    public Guid? StudentId { get; set; }

    public class GetByIdGraduationProcessQueryHandler : IRequestHandler<GetByIdGraduationProcessQuery, GetByIdGraduationProcessResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationProcessRepository _graduationProcessRepository;
        private readonly GraduationProcessBusinessRules _graduationProcessBusinessRules;

        public GetByIdGraduationProcessQueryHandler(
            IMapper mapper, 
            IGraduationProcessRepository graduationProcessRepository,
            GraduationProcessBusinessRules graduationProcessBusinessRules)
        {
            _mapper = mapper;
            _graduationProcessRepository = graduationProcessRepository;
            _graduationProcessBusinessRules = graduationProcessBusinessRules;
        }

        public async Task<GetByIdGraduationProcessResponse> Handle(GetByIdGraduationProcessQuery request, CancellationToken cancellationToken)
        {
            // Validation: Either Id or StudentId must be provided
            if (!request.Id.HasValue && !request.StudentId.HasValue)
                throw new ArgumentException("Either Id or StudentId must be provided");

            if (request.Id.HasValue && request.StudentId.HasValue)
                throw new ArgumentException("Only one of Id or StudentId should be provided");

            // Build predicate based on provided parameter
            System.Linq.Expressions.Expression<System.Func<GraduationProcess, bool>> predicate;
            if (request.Id.HasValue)
                predicate = gp => gp.Id == request.Id.Value;
            else
                predicate = gp => gp.StudentId == request.StudentId.Value;

            GraduationProcess? graduationProcess = await _graduationProcessRepository.GetAsync(
                predicate: predicate,
                cancellationToken: cancellationToken
            );

            await _graduationProcessBusinessRules.GraduationProcessShouldExistWhenSelected(graduationProcess);

            GetByIdGraduationProcessResponse response = _mapper.Map<GetByIdGraduationProcessResponse>(graduationProcess);
            return response;
        }
    }
}