using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.ViewModels
{
    public class RegisterModel
    {
        [EmailAddress(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }
         
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
         
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Не указана дата рождения")]
        public DateTime DateOfBirthday { get; set; }
    }
}