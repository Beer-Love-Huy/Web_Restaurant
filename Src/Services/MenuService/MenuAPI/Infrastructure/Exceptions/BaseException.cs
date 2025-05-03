namespace MenuAPI.Infrastructure.Exceptions
{
    public class BaseException : Exception
    {
        public int StatusCode { get; set; }

        public BaseException(string message, int statusCode = 500)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public BaseException(string message, Exception innerException, int statusCode = 500)
            : base(message,innerException)
        {
            StatusCode = statusCode;
        }
    }
}
