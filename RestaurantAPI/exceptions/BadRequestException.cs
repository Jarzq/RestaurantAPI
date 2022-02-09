using System;

namespace RestaurantAPI.exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
                
        }
    }
}
