using System;

namespace MenuAPI.Infrastructure.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException (string message = "Unauthorized request.")
            : base(message, 401)
        {

        }
    }
}
