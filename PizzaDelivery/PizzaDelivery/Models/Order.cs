namespace PizzaDelivery.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int PizzaId { get; set; }

        public int AdditionalProductId { get; set; }
    }
}