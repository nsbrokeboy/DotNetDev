namespace PizzaDelivery.Models
{
    public class Order
    {
        public int Id { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public Pizza Pizza { get; set; }
        public int PizzaId { get; set; }

        public AdditionalProduct AdditionalProduct { get; set; }
        public int AdditionalProductId { get; set; }
    }
}