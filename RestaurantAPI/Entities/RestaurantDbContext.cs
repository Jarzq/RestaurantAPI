using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
//using DbContext = System.Data.Entity.DbContext;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
                
        }
        public Microsoft.EntityFrameworkCore.DbSet<Restaurant> Restaurants { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Address> Addresses { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Dish> Dishes { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(d=>d.Name)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(51);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();

        }

    }
}
