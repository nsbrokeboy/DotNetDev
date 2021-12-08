using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Models
{
    public class CartItem
    {
        [Key]
        public string CartItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}