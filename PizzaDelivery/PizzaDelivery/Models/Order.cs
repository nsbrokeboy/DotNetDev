using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PizzaDelivery.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        [NotNull]
        public CartItem CartItem { get; set; }
        
        [NotNull]
        public string CartItemId { get; set; }
        
        public string Address { get; set; }
        
    }
}