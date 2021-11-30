using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Data;

namespace PizzaDelivery.Controllers
{
    public class AdditionalProductController : Controller
    {
        private readonly PizzaDeliveryDbContext _context;

        public AdditionalProductController(PizzaDeliveryDbContext context)
        {
            _context = context;
        }

        [Route("AdditionalProduct/{id:int}")]
        public IActionResult Index(int id)
        {
            var product = _context.AdditionalProducts.FirstOrDefault(x => x.Id == id);
            
            return View(product);
        }
    }
}