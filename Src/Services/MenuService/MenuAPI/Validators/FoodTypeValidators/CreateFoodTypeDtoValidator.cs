using System.Data;
using FluentValidation;
using MenuAPI.Models.DTOs;

namespace MenuAPI.Validators.FoodTypeValidators
{
    public class CreateFoodTypeDtoValidator : AbstractValidator<CreateFoodTypeDto>
    {
        public CreateFoodTypeDtoValidator()
        {
            RuleFor(x => x.NameFoodType)
                .NotEmpty().WithMessage(ValidatorMessages.NameFoodTypeNotemptyMessage)
                .MaximumLength(100).WithMessage(ValidatorMessages.NameFoodTypeMaxLengthMessage)
                .MinimumLength(5).WithMessage(ValidatorMessages.NameFoodTypeMinLengthMessage);
        }
    }
}
