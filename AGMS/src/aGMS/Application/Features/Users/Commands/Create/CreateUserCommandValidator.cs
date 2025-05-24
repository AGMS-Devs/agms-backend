using Domain.Enums;
using FluentValidation;

namespace Application.Features.Users.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
        RuleFor(c => c.Surname).NotEmpty().MinimumLength(2);
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.Password).NotEmpty().MinimumLength(4);
        RuleFor(c => c.UserType).IsInEnum();
        RuleFor(c => c.PhoneNumber)
            .Matches(@"^\+?[0-9]{10,15}$")
            .When(c => !string.IsNullOrEmpty(c.PhoneNumber))
            .WithMessage("Geçerli bir telefon numarası giriniz.");
    }
}
