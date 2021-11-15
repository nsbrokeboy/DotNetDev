namespace PizzaDelivery.Models
{
    public class Pizza
    {
        public int Id { get; set; }
       
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public double Weight { get; set; }

        public string Description { get; set; }
    }
}