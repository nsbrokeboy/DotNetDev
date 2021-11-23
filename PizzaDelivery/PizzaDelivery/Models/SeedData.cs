using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Data;
using PizzaDelivery.Models;


public static class SeedData
{
    public static void Initialize(PizzaDeliveryDbContext PizzaDeliveryDbContext)
    {
        if (PizzaDeliveryDbContext == null || PizzaDeliveryDbContext.Pizzas == null)
        {
            throw new ArgumentNullException("Null PizzaDeliveryDbContext");
        }

        if (PizzaDeliveryDbContext.Pizzas.Any())
        {
            return; // DB has been seeded
        }

        PizzaDeliveryDbContext.Pizzas.AddRange(
            new Pizza()
            {
                Id = 1,
                Name = "Пепперони",
                Cost = 349,
                Weight = 520,
                Description = "Пикантная пепперони, увеличенная порция моцареллы, томаты, томатный соус"
            },
            new Pizza()
            {
                Id = 2,
                Name = "Маргарита",
                Cost = 369,
                Weight = 620,
                Description = "Увеличенная порция моцареллы, томаты, итальянские травы, томатный соус"
            },
            new Pizza()
            {
                Id = 3,
                Name = "Четыре сыра",
                Cost = 445,
                Weight = 550,
                Description = "Сыр блю чиз, сыры чеддер и пармезан, моцарелла, соус альфредо"
            },
            new Pizza()
            {
                Id = 4,
                Name = "Гавайская",
                Cost = 599,
                Weight = 640,
                Description = "Ветчина, ананасы, моцарелла, томатный соус"
            },
            new Pizza()
            {
                Id = 5,
                Name = "С морепродуктами",
                Cost = 829,
                Weight = 650,
                Description = "Мидии, томаты, креветки, моцарелла, соус альфредо"
            },
            new Pizza()
            {
                Id = 6,
                Name = "Мясная",
                Cost = 779,
                Weight = 640,
                Description = "Пикантная пепперони, цыпленок, острая чоризо, бекон, митболы, моцарелла, томатный соус"
            },
            new Pizza()
            {
                Id = 7,
                Name = "Грибная",
                Cost = 399,
                Weight = 680,
                Description =
                    "Шампиньоны, томаты, сладкий перец, красный лук, маслины, кубики брынзы, моцарелла, томатный соус, итальянские травы"
            },
            new Pizza()
            {
                Id = 8,
                Name = "Четыре сезона",
                Cost = 399,
                Weight = 680,
                Description =
                    "Увеличенная порция моцареллы, ветчина, пикантная пепперони, кубики брынзы, томаты, шампиньоны, итальянские травы, томатный соус"
            });
            if (PizzaDeliveryDbContext == null || PizzaDeliveryDbContext.AdditionalProducts == null)
        {
            throw new ArgumentNullException("Null PizzaDeliveryDbContext");
        }

        if (PizzaDeliveryDbContext.AdditionalProducts.Any())
        {
            return; // DB has been seeded
        }

        PizzaDeliveryDbContext.AdditionalProducts.AddRange(
            new AdditionalProduct()
            {
                Id = 1,
                Name = "Coca-Cola",
                Cost = 69
            },
             new AdditionalProduct(){
                 Id =2,
                 Name = "Sprite",
                 Cost = 69
            },
            new AdditionalProduct(){
                Id =3,
                Name = "Fanta",
                Cost = 69
            },
            new AdditionalProduct(){
                Id =4,
                Name = "Lipton",
                Cost = 79
            },
            new AdditionalProduct(){
                Id =5,
                Name = "Orbit",
                Cost = 39
            },
            new AdditionalProduct(){
                Id =6,
                Name = "Влажная салфетка",
                Cost = 5
            },
            new AdditionalProduct(){
                Id =7,
                Name = "Фирменный магнит",
                Cost = 99
            },
            new AdditionalProduct(){
                Id =8,
                Name = "Морс",
                Cost = 49
            },
            new AdditionalProduct(){
                Id =9,
                Name = "Сок апельсиновый",
                Cost = 79
            },
            new AdditionalProduct(){
                Id = 10,
                Name = "Сок яблочный",
                Cost = 79
            });;
        PizzaDeliveryDbContext.SaveChanges(); //?
    }
}
