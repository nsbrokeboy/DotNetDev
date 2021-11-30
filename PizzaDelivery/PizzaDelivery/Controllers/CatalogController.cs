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

        public IActionResult AllProducts()
        {
            var catalog = new AllProductsModel
            {
                Pizzas = _context.Pizzas.ToList(), AdditionalProducts = _context.AdditionalProducts.ToList()
            };

            return View(catalog);
        }
    }
}