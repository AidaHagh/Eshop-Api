using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.Register
{
    public class RegisterUserCommandValidator:AbstractValidator<RegisterUserCommand> 
    {
        public RegisterUserCommandValidator()
        {

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
                .NotNull().WithMessage(ValidationMessages.required("کلمه عبور"))
                .MinimumLength(4).WithMessage("کلمه عبور باید بیشتر از چهار رقم باشد");
        }
    }
}
