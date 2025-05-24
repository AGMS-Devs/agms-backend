using FluentValidation;

namespace Application.Features.Users.Commands.Update;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
        RuleFor(c => c.Surname).NotEmpty().MinimumLength(2);
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.PhoneNumber).NotEmpty().MinimumLength(10);
        RuleFor(c => c.Password).NotEmpty().MinimumLength(4);
        RuleFor(c => c.UserType).NotEmpty();
    }
}
