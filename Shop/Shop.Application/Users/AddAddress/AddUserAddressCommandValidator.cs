using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.AddAddress;

public class AddUserAddressCommandValidator : AbstractValidator<AddUserAddressCommand>
{
    public AddUserAddressCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage(ValidationMessages.required("نام"));

        RuleFor(r => r.Family)
            .NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));

        RuleFor(r => r.Province)
            .NotEmpty().WithMessage(ValidationMessages.required("استان"));

        RuleFor(r => r.City)
            .NotEmpty().WithMessage(ValidationMessages.required("شهر"));

        RuleFor(r => r.PostalAddress)
            .NotEmpty().WithMessage(ValidationMessages.required("آدرس"));

        RuleFor(r => r.PostalCode)
            .NotEmpty().WithMessage(ValidationMessages.required("کدپستی"))
            .MinimumLength(10)
            .MaximumLength(10);

        RuleFor(r => r.NationalCode)
            .NotEmpty().WithMessage(ValidationMessages.required("کدملی"))
            .ValidNationalId();
    }

}

