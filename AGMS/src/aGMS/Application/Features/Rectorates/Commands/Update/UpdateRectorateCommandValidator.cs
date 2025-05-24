using FluentValidation;

namespace Application.Features.Rectorates.Commands.Update;

public class UpdateRectorateCommandValidator : AbstractValidator<UpdateRectorateCommand>
{
    public UpdateRectorateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentAffairId).NotEmpty();
        RuleFor(c => c.StudentAffair).NotEmpty();
    }
}