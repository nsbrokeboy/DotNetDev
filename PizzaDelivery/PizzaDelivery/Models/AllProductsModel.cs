using System.Collections.Generic;

namespace PizzaDelivery.Models
{
    public class AllProductsModel
    {
        public List<Pizza> Pizzas { get; set; }

        public List<AdditionalProduct> AdditionalProducts { get; set; }
    }
}