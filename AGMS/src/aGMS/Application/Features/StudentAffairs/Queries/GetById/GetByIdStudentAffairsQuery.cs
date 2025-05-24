using Application.Features.StudentAffairs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentAffairs.Queries.GetById;

public class GetByIdStudentAffairsQuery : IRequest<GetByIdStudentAffairsResponse>
{
    public Guid Id { get; set; }

    public class GetByIdStudentAffairsQueryHandler : IRequestHandler<GetByIdStudentAffairsQuery, GetByIdStudentAffairsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentAffairRepository _studentAffairRepository;
        private readonly StudentAffairsBusinessRules _studentAffairsBusinessRules;

        public GetByIdStudentAffairsQueryHandler(IMapper mapper, IStudentAffairRepository studentAffairRepository, StudentAffairsBusinessRules studentAffairsBusinessRules)
        {
            _mapper = mapper;
            _studentAffairRepository = studentAffairRepository;
            _studentAffairsBusinessRules = studentAffairsBusinessRules;
        }

        public async Task<GetByIdStudentAffairsResponse> Handle(GetByIdStudentAffairsQuery request, CancellationToken cancellationToken)
        {
            StudentAffair? studentAffair = await _studentAffairRepository.GetAsync(predicate: sa => sa.Id == request.Id, cancellationToken: cancellationToken);
            await _studentAffairsBusinessRules.StudentAffairShouldExistWhenSelected(studentAffair);

            GetByIdStudentAffairsResponse response = _mapper.Map<GetByIdStudentAffairsResponse>(studentAffair);
            return response;
        }
    }
}