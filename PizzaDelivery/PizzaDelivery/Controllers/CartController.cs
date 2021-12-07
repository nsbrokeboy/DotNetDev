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

        public IActionResult IncreaseQuantity(int id)
        {
            _actions.ChangeQuantity(id,1);
            return View("Cart");
        }
        public IActionResult DecreaseQuantity(int id)
        {
            _actions.ChangeQuantity(id,-1);
            return View("Cart");
        }

        public IActionResult Remove(int id)
        {
            _actions.RemoveFromCart(id);
            return View("Cart");
        }

        public IActionResult RemoveAll()
        {
            _actions.RemoveAllPositions();
            return View("Cart");
        }


    }
}