using FluentValidation;
using MenuAPI.Models.DTOs;

namespace MenuAPI.Validators.FoodTypeValidators
{
    public class UpdateFoodTypeDtoValidator : AbstractValidator<UpdateFoodTypeDto>
    {
        public UpdateFoodTypeDtoValidator()
        {
            RuleFor(x => x.IdFoodType)
                .NotEmpty().WithMessage(ValidatorMessages.IdFoodTypeNotemptyMessage)
                .GreaterThan(0).WithMessage(ValidatorMessages.IdFoodTypeGreaterThanMessage);

            RuleFor(x => x.NameFoodType)
                .NotEmpty().WithMessage(ValidatorMessages.NameFoodTypeNotemptyMessage)
                .MaximumLength(100).WithMessage(ValidatorMessages.NameFoodTypeMaxLengthMessage)
                .MinimumLength(5).WithMessage(ValidatorMessages.NameFoodTypeMinLengthMessage);
        }
    }
}
