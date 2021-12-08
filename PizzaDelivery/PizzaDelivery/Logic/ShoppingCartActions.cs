using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.AspNetCore.Http;
using PizzaDelivery.Data;
using PizzaDelivery.Models;

namespace PizzaDelivery.Logic
{
    public class ShoppingCartActions
    {
        private readonly PizzaDeliveryDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingCartActions(PizzaDeliveryDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public void AddToCart(int id)
        {
            ShoppingCartId = GetCartId();

            var cartItem = _context.ShoppingCartItems.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                     && c.ProductId == id);

            if (cartItem == null)
            {
                if (_context.Pizzas.Any(p => p.Id == id))
                {
                    // Create a new cart item if no cart item exists.                 
                    cartItem = new CartItem
                    {
                        ItemId = Guid.NewGuid().ToString(),
                        ProductId = id,
                        CartId = ShoppingCartId,
                        Product = _context.Pizzas.FirstOrDefault(p => p.Id == id),
                        Quantity = 1,
                    };
                }
                else
                {
                    cartItem = new CartItem
                    {
                        ItemId = Guid.NewGuid().ToString(),
                        ProductId = id,
                        CartId = ShoppingCartId,
                        Product = _context.AdditionalProducts.FirstOrDefault(p => p.Id == id),
                        Quantity = 1,
                    };
                }


                _context.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            _context.SaveChanges();
        }

        public void RemoveFromCart(int id)
        {
            ShoppingCartId = GetCartId();
            _context.ShoppingCartItems.Remove(_context.ShoppingCartItems.FirstOrDefault(
                c => c.CartId == ShoppingCartId && c.ProductId == id));

            _context.SaveChanges();
        }

        public void ChangeQuantity(int id, int dif)
        {
            ShoppingCartId = GetCartId();
            var item = _context.ShoppingCartItems.FirstOrDefault(
                c => c.CartId == ShoppingCartId && c.ProductId == id);

            item.Quantity += dif;

            if (item.Quantity <= 0)
            {
                RemoveFromCart(id);
            }
            else
            {
                _context.SaveChanges();
            }
        }

        public string GetCartId()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("CartSessionKey") == null)
            {
                if (!string.IsNullOrWhiteSpace(_httpContextAccessor.HttpContext.User.Identity.Name))
                {
                    // возможно, нужно делать через _httpContextAccessor
                    _httpContextAccessor.HttpContext.Session.SetString(CartSessionKey,
                        _httpContextAccessor.HttpContext.User.Identity.Name);
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    _httpContextAccessor.HttpContext.Session.SetString(CartSessionKey, tempCartId.ToString());
                }
            }

            return _httpContextAccessor.HttpContext.Session.GetString(CartSessionKey);
        }

        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            var cart = _context.ShoppingCartItems.Where(
                c => c.CartId == ShoppingCartId).ToList();

            foreach (var item in cart)
            {
                if (_context.Pizzas.Any(p => p.Id == item.ProductId))
                {
                    item.Product = _context.Pizzas.FirstOrDefault(p => p.Id == item.ProductId);
                }
                else
                {
                    item.Product = _context.AdditionalProducts.FirstOrDefault(p => p.Id == item.ProductId);
                }
            }

            return cart;
        }

        public void RemoveAllPositions()
        {
            ShoppingCartId = GetCartId();
            _context.ShoppingCartItems.RemoveRange(_context.ShoppingCartItems.Where(i => i.CartId == ShoppingCartId));

            _context.SaveChanges();
        }

        public void MakeOrder()
        {
            ShoppingCartId = GetCartId();
            var cart = GetCartItems();

            if (_context.Orders.Any(o => o.Item.CartId == ShoppingCartId))
            {
                foreach (var item in cart)
                {
                    _context.Orders.Add(new Order()
                    {
                        Item = item,
                        OrderId = 1
                    });
                }
            }
            else
            {
                int orderId = _context.Orders.OrderBy(o => o.OrderId)
                    .LastOrDefault(o => o.Item.CartId == ShoppingCartId).OrderId;
                foreach (var item in cart)
                {
                    _context.Orders.Add(new Order()
                    {
                        Item = item,
                        OrderId = orderId + 1
                    });
                }
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.Where(o => o.Item.CartId == ShoppingCartId).ToList();
        }
    }
}