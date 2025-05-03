using System;

namespace MenuAPI.Infrastructure.Exceptions
{
    public class BadRequestException : BaseException
    {
        // FoodType
        public const string NameFoodTypeAreadyExistsMessage = "NameFoodType already exists";
        public const string IdFoodTypeMismatchMessage = "IdFoodType in URL does not match Id in the body";
        public const string IdFoodMismatchMessage = "IdFood in URL does not match Id in the body";

        //Food
        public const string NameFoodAreadyExistsMessage = "NameFood already exists";
        public BadRequestException(string message = "Bad Request")
            : base(message, 400)
        {
        }
    }
}
