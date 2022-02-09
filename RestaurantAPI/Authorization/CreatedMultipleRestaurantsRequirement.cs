using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Authorization
{
    public class CreatedMultipleRestaurantsRequirement : IAuthorizationRequirement
    {
        public CreatedMultipleRestaurantsRequirement(int minimumRestaurantsCreated)
        {
            MimimumRestaurantsCreated = minimumRestaurantsCreated;
        }
        public int MimimumRestaurantsCreated { get; set; }
    }
}
