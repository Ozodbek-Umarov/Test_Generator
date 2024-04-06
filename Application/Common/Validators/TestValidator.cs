using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;

public class TestValidator :AbstractValidator<Test>
{
    public TestValidator()
    {
        RuleFor(x => x.Question)
            .NotEmpty().WithMessage("Savol bosh bolmasligi kerak");
    }
}
