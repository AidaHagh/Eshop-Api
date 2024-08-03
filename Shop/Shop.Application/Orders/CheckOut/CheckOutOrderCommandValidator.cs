using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Orders.CheckOut;

public class CheckOutOrderCommandValidator : AbstractValidator<CheckOutOrderCommand>
{
    public CheckOutOrderCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("نام"));

        RuleFor(r => r.Family)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("نام خانوادگی"));

        RuleFor(r => r.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("شماره تماس"))
            .MaximumLength(11).WithMessage("شماره موبایل نامعتبر است.")
            .MinimumLength(11).WithMessage("شماره موبایل نامعتبر است.");

        RuleFor(r => r.NationalCode)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("کدملی"))
            .MaximumLength(10).WithMessage(" کدملی نامعتبر است.")
            .MinimumLength(10).WithMessage(" کدملی نامعتبر است.")
            .ValidNationalId();

        RuleFor(r => r.City)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("شهر"));

        RuleFor(r => r.Province)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("استان"));

        RuleFor(r => r.PostalCode)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("کدپستی"))
            .MaximumLength(10).WithMessage(" کدپستی نامعتبر است.")
            .MinimumLength(10).WithMessage(" کدپستی نامعتبر است.");

        RuleFor(r => r.PostalAddress)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("آدرس"));


    }
}

