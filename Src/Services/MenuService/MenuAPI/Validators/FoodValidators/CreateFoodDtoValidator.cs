using FluentValidation;
using MenuAPI.Models.DTOs;

namespace MenuAPI.Validators.FoodValidators
{
    public class CreateFoodDtoValidator : AbstractValidator<CreateFoodDto>
    {
        public CreateFoodDtoValidator()
        {
            RuleFor(x => x.NameFood)
                .NotEmpty().WithMessage(ValidatorMessages.NameFoodNotemptyMessage);

            RuleFor(x => x.PriceFood)
                .NotEmpty().WithMessage(ValidatorMessages.PriceFoodNotemptyMessage)
                .GreaterThan(0).WithMessage(ValidatorMessages.PriceFoodGreaterThanMessage);

            RuleFor(x => x.ImgFood)
                .MaximumLength(255).WithMessage(ValidatorMessages.ImgFoodMaxLengthMessage);

            RuleFor(x => x.IdFoodType)
                .NotEmpty().WithMessage(ValidatorMessages.IdFoodTypeNotemptyMessage)
                .GreaterThan(0).WithMessage(ValidatorMessages.IdFoodTypeGreaterThanMessage);
        }
    }
}
