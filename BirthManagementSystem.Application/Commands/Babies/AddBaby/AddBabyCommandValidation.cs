using FluentValidation;

namespace BirthManagementSystem.Application.Commands.Babies.AddBaby;

public class AddBabyCommandValidation : AbstractValidator<AddBabyCommand>
{
    public AddBabyCommandValidation()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name cannot be longer than 50 characters.");

        RuleFor(x => x.SecondName)
            .MaximumLength(50).WithMessage("Second name cannot be longer than 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name cannot be longer than 50 characters.");

        RuleFor(x => x.PersonalIdentityNumber)
            .NotEmpty().WithMessage("PESEL is required.")
            .MaximumLength(11).WithMessage("PESEL cannot be longer than 11 numbers.");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("Date of birth is required.");

        RuleFor(x => x.StreetName)
            .NotEmpty().WithMessage("Street name is required.")
            .MaximumLength(120).WithMessage("Street name cannot be longer than 120 characters.");

        RuleFor(x => x.StreetNumber)
            .NotEmpty().WithMessage("Street number is required.")
            .MaximumLength(16).WithMessage("Street number cannot be longer than 16 characters.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .MaximumLength(100).WithMessage("City name cannot be longer than 100 characters.");

        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("Postal code is required.")
            .MaximumLength(16).WithMessage("Postal code cannot be longer than 120 characters.");
    }
}
