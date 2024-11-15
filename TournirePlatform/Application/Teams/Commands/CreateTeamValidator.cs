using FluentValidation;

namespace Application.Teams.Commands;

public class CreateTeamValidator : AbstractValidator<CreateTeamCommand>
{
    public CreateTeamValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
        RuleFor(x => x.CreationDate).NotEmpty();
    }
}