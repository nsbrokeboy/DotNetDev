using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Data;
using PizzaDelivery.Models;

{
     public static class SeedData
     {
         public static void Initialize(DbContext PizzaDeliveryDbContext)
         {
             using (var context = new PizzaDeliveryDbContext(PizzaDeliveryDbContext.Database.)) //?
             {
                 if (context == null || context.Pizzas == null)
                 {
                     throw new ArgumentNullException("Null PizzaDeliveryDbContext");
                 }
                 
                 if (context.Pizzas.Any())
                 {
                     return;   // DB has been seeded
                 }

                 context.Pizzas.AddRange(
                     new Pizza()
                     {
                         Id = 1,
                         Name = "Peperoni",
                         Cost = ,
                         Weight = ,
                         Description = 
                     },

                     new Pizza()
                     {
                         Id = 2,
                         Name = "Margarita",
                         Cost = ,
                         Weight = ,
                         Description = 
                     },
                     new Pizza()
                     {
                         Id = 3,
                         Name = "Four cheeses",
                         Cost = ,
                         Weight = ,
                         Description = 
                     },
                     new Pizza()
                     {
                         Id = 4,
                         Name = "Hawaiian",
                         Cost = ,
                         Weight = ,
                         Description = 
                     },
                     new Pizza()
                     {
                         Id = 5,
                         Name = "Seafood",
                         Cost = ,
                         Weight = ,
                         Description = 
                     },
                     new Pizza()
                     {
                         Id = 6,
                         Name = "Meat",
                         Cost = ,
                         Weight = ,
                         Description = 
                     },
                     new Pizza()
                     {
                         Id = 7,
                         Name = "Mushroom",
                         Cost = ,
                         Weight = ,
                         Description = 
                     },
                     new Pizza()
                     {
                         Id = 8,
                         Name = "Four seasons",
                         Cost = ,
                         Weight = ,
                         Description = 
                     },
                 context.SaveChanges();  //?
             }
         }
     }
 }
