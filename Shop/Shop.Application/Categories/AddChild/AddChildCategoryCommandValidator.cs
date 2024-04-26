using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryCommandValidator:AbstractValidator<AddChildCategoryCommand>
    {

        public AddChildCategoryCommandValidator()
        {
            RuleFor(r=>r.title)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(r=>r.slug)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("slug"));
        }


    }
   
}
