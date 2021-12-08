using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PizzaDelivery.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
        
        public string Username { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string Address { get; set; }
        
    }
}