using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Models;

namespace PizzaDelivery.Data
{
    public class PizzaDeliveryDbContext : DbContext
    {
        public PizzaDeliveryDbContext(DbContextOptions<PizzaDeliveryDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AdditionalProduct> AdditionalProducts { get; set; }
        
        public DbSet<CartItem> ShoppingCartItems { get; set; }
        
        public DbSet<Order> Orders { get; set; }
    }
}