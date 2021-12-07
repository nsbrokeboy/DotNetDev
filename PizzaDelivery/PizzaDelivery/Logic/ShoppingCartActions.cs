using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using PizzaDelivery.Data;
using PizzaDelivery.Models;

namespace PizzaDelivery.Logic
{
    public class ShoppingCartActions : IDisposable
    {
        private readonly PizzaDeliveryDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;    
        private readonly ISession _session;

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
        
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
        
        public string GetCartId()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("CartSessionKey") == null)
            {
                if (!string.IsNullOrWhiteSpace(_httpContextAccessor.HttpContext.User.Identity.Name))
                {
                    // возможно, нужно делать через _httpContextAccessor
                    _httpContextAccessor.HttpContext.Session.SetString(CartSessionKey, _httpContextAccessor.HttpContext.User.Identity.Name);
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
    }
}