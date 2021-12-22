using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Data;
using PizzaDelivery.Models;

namespace PizzaDelivery.Controllers
{
    public class CatalogController : Controller
    {
        private readonly PizzaDeliveryDbContext _context;
        
        public CatalogController(PizzaDeliveryDbContext dbContext)
        {
            _context = dbContext;
        }
        
        public IActionResult AllProducts(int cost)
        {
            if (cost == 0)
            {
                cost = 1000;
            }

            var catalog = new AllProductsModel
            {
                Pizzas = _context.Pizzas.Where(p => p.Cost <= cost).ToList(), 
                AdditionalProducts = _context.AdditionalProducts.Where(p => p.Cost <= cost).ToList(),
                MaxCost = cost
            };

            return View(catalog);
        }
    }
}