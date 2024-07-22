using FluentValidation;

namespace BirthManagementSystem.Application.Commands.Babies.UpdateBaby;

public class UpdateBabyCommandValidation : AbstractValidator<UpdateBabyCommand>
{
    public UpdateBabyCommandValidation()
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
    }
}
