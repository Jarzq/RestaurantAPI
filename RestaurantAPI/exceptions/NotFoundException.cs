using System;

namespace RestaurantAPI.exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) :base(message)
        {

        }
    }
}
