using Demo.Shared.Entities;
using FluentValidation;

namespace DemoProject.Validators;

public class BurgerValidator : AbstractValidator<Burger>
{
    public BurgerValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Vul in aub");
        RuleFor(x => x.Name).Matches("^Mc[A-Z][a-zA-Z]+$").WithMessage("Begin met Mc en fatsoenlijke naam graag");
        RuleFor(x => x.Name).MinimumLength(5).WithMessage("Minimaal 5 karakters");

        RuleFor(x => x.Price).NotEmpty().WithMessage("Vul in aub");

        When(x => x.Price > 10M, () =>
        {
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Vul in aub");
            RuleFor(x => x.Rating).GreaterThanOrEqualTo(1m).WithMessage("Minimaal een 1 graag");
        });

        RuleFor(x => x.PhotoUrl).NotEmpty().WithMessage("Vul in aub");
    }
}
