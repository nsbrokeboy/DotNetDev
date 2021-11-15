namespace PizzaDelivery.Models
{
    public class Pizza
    {
        /// <summary>
        /// Pizza's ID
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Pizza's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Pizza's cost 
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Pizza's weight
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Pizza's description
        /// </summary>
        public string Description { get; set; }
    }
}