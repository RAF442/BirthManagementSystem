using FluentValidation;

namespace BirthManagementSystem.Application.Commands.ApgarScores.AddApgarScore;

public class AddApgarScoreValidation : AbstractValidator<AddApgarScoreCommand>
{
    public AddApgarScoreValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name cannot be longer than 50 characters.");

        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("Value is required.");
    }
}
