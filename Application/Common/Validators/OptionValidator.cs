using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;

public class OptionValidator : AbstractValidator<Option>
{
    public OptionValidator()
    {
        RuleFor(x => x.Variant)
            .NotEmpty().WithMessage("variantlar bosh bo'lmasin");
        RuleFor(x => x.TestId)
            .GreaterThan(0).WithMessage("test 0 bolmasligi kerak");
    }
}
