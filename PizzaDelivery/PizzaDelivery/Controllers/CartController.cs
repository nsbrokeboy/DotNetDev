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

        public IActionResult IncreaseQuantity(int id, string url)
        {
            _actions.ChangeQuantity(id,1);
            return Redirect(url);
        }
        public IActionResult DecreaseQuantity(int id, string url)
        {
            _actions.ChangeQuantity(id,-1);
            return Redirect(url);
        }

        public IActionResult Remove(int id, string url)
        {
            _actions.RemoveFromCart(id);
            return Redirect(url);
        }

        public IActionResult RemoveAll(string url)
        {
            _actions.RemoveAllPositions();
            return Redirect(url);
        }

        public IActionResult PreOrder()
        {
            return View(_actions.GetCartItems());
        }

        public IActionResult MakeOrder()
        {
            _actions.MakeOrder();
            _actions.RemoveAllPositions();
            return View();
        }
    }
}