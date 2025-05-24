using System.Text.RegularExpressions;
using FluentValidation;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(c => c.UserForRegisterDto.Email)
            .NotEmpty()
            .EmailAddress()
            .Must(email => email.EndsWith("@std.iyte.edu.tr") || email.EndsWith("@iyte.edu.tr"))
            .WithMessage("Email adresi @std.iyte.edu.tr veya @iyte.edu.tr ile bitmelidir.");

        RuleFor(c => c.UserForRegisterDto.Password)
            .NotEmpty()
            .MinimumLength(6)
            .WithMessage("Şifre en az 6 karakter olmalıdır.")
            .Matches("[A-Z]")
            .WithMessage("Şifre en az bir büyük harf içermelidir.")
            .Matches("[a-z]")
            .WithMessage("Şifre en az bir küçük harf içermelidir.")
            .Matches("[0-9]")
            .WithMessage("Şifre en az bir rakam içermelidir.")
            .Matches("[^a-zA-Z0-9]")
            .WithMessage("Şifre en az bir özel karakter içermelidir.");

        RuleFor(c => c.UserForRegisterDto.Name)
            .NotEmpty()
            .WithMessage("Ad alanı boş bırakılamaz.")
            .MinimumLength(2)
            .WithMessage("Ad en az 2 karakter olmalıdır.");

        RuleFor(c => c.UserForRegisterDto.Surname)
            .NotEmpty()
            .WithMessage("Soyad alanı boş bırakılamaz.")
            .MinimumLength(2)
            .WithMessage("Soyad en az 2 karakter olmalıdır.");

        RuleFor(c => c.UserForRegisterDto.PhoneNumber)
            .Matches(@"^[0-9]{10}$")
            .When(c => !string.IsNullOrEmpty(c.UserForRegisterDto.PhoneNumber))
            .WithMessage("Telefon numarası 10 haneli olmalıdır (Örnek: 5551234567).");
    }

    private bool StrongPassword(string value)
    {
        Regex strongPasswordRegex = new("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", RegexOptions.Compiled);

        return strongPasswordRegex.IsMatch(value);
    }
}
