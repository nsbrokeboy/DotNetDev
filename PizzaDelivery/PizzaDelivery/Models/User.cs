using System;

namespace PizzaDelivery.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public DateTime DateOfBirthday { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}