namespace MenuAPI.Infrastructure.Exceptions
{
    public class NotFoundException : BaseException
    {
        public const string IdFoodNotFoundMessage = "IdFood not found";
        public const string IdFoodTypeNotFoundMessage = "IdFoodType not found";
        public NotFoundException (string message = "The requested resource was not found")
            : base(message, 404)
        {

        }
    }
}
