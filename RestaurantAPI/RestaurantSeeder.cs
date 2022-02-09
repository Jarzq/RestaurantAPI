using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();

                }
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                 {
                    Name = "Admin"
                 },
            };
            return roles;

        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var Restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "Kurczaki sie tam je",
                    ContactEmail = "Kfc@k.com",
                    HasDelivery = true,

                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Hot Chicken",
                            Price = 10.30M,

                        },

                        new Dish()
                        {
                            Name = "Nuggets",
                            Price = 5.30M,

                        },

                    },
                    Address = new Address()
                    {
                        City = "KRaków",
                        Street = "Dluga 5",
                        PostalCode = "30-001"
                    }

                },
                new Restaurant()
                {
                    Name = "MC",
                    Category = "Fast Food",
                    Description = "wszystko sie tam je",
                    ContactEmail = "MC@k.com",
                    HasDelivery = true,

                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Drwal",
                            Price = 16.30M,

                        },

                        new Dish()
                        {
                            Name = "Nuggets",
                            Price = 6.30M,

                        },

                    },
                    Address = new Address()
                    {
                        City = "Warszawa",
                        Street = "Bura 55",
                        PostalCode = "30-401"
                    }

                }

            };
            return Restaurants;
        }
    }
}
