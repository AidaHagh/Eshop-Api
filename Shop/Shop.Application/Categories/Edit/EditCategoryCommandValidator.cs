using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.Edit
{
    public class EditCategoryCommandValidator :AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidator()
        {
            RuleFor(r=>r.title)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("عنوان")); 
            RuleFor(r=>r.slug)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("Slug")); 
        }
    }
  
}
