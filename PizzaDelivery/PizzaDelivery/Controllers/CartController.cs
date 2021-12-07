using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Logic;
using PizzaDelivery.Models;

namespace PizzaDelivery.Controllers
{
    public class CartController : Controller
    {
        private readonly ShoppingCartActions _actions;

        public CartController(ShoppingCartActions actions)
        {
            _actions = actions;
        }

        public IActionResult AddToCart(int id, string url)
        {
            _actions.AddToCart(id);
            
            return Redirect(url);
        }

        public IActionResult Cart()
        {
            return View(_actions.GetCartItems());
        }
        
        
    }
}