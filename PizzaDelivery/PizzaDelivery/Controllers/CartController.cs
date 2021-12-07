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

        public void AddToCart(int id)
        {
            _actions.AddToCart(id);
        }

        public IActionResult Cart()
        {
            return View(_actions.GetCartItems());
        }
        
        
    }
}