using Application.Features.StudentAffairs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentAffairs.Commands.Create;

public class CreateStudentAffairsCommand : IRequest<CreatedStudentAffairsResponse>
{
    public string OfficeName { get; set; }

    public class CreateStudentAffairsCommandHandler : IRequestHandler<CreateStudentAffairsCommand, CreatedStudentAffairsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentAffairRepository _studentAffairRepository;
        private readonly StudentAffairsBusinessRules _studentAffairsBusinessRules;

        public CreateStudentAffairsCommandHandler(IMapper mapper, IStudentAffairRepository studentAffairRepository,
                                         StudentAffairsBusinessRules studentAffairsBusinessRules)
        {
            _mapper = mapper;
            _studentAffairRepository = studentAffairRepository;
            _studentAffairsBusinessRules = studentAffairsBusinessRules;
        }

        public async Task<CreatedStudentAffairsResponse> Handle(CreateStudentAffairsCommand request, CancellationToken cancellationToken)
        {
            StudentAffair studentAffair = _mapper.Map<StudentAffair>(request);

            await _studentAffairRepository.AddAsync(studentAffair);

            CreatedStudentAffairsResponse response = _mapper.Map<CreatedStudentAffairsResponse>(studentAffair);
            return response;
        }
    }
}