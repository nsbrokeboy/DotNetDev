using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Models;

namespace PizzaDelivery.Data
{
    public class PizzaDBContext : DbContext
    {
        public PizzaDBContext(DbContextOptions<PizzaDBContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        
        public DbSet<Pizza> Pizzas { get; set; }
    }
}