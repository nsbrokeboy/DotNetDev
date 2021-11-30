using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Data;

namespace PizzaDelivery.Controllers
{
    public class PizzaController : Controller
    {
        private readonly PizzaDeliveryDbContext _context;
        
        public PizzaController(PizzaDeliveryDbContext context)
        {
            _context = context;
        }
        
        [Route("Pizza/{id:int}")]
        public IActionResult Index(int id)
        {
            var pizza = _context.Pizzas.FirstOrDefault(x => x.Id == id);

            return View(pizza);
        }
    }
}