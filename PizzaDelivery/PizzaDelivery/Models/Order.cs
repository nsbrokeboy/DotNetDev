using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public CartItem Item { get; set; }
        
        public string Address { get; set; }
        
    }
}