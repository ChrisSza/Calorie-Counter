using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Calorie_Counter.Models
{
    public class DatabaseInitialiser : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);
            if (!context.Users.Any())
            {
                var dairy = new FoodCategory { CategoryName = "Dairy" };
                var fruit = new FoodCategory { CategoryName = "Fruit" };
                var meats = new FoodCategory { CategoryName = "Meat" };
                var vegtables = new FoodCategory { CategoryName = "Vegtables" };

                context.FoodCategories.Add(dairy);
                context.FoodCategories.Add(fruit);
                context.FoodCategories.Add(meats);
                context.FoodCategories.Add(vegtables);
                context.SaveChanges();

                context.Foods.Add(new Food()
                {
                    FoodName = "Steak",
                    ImageUrl = "/Images/beef.jpg",
                    FoodDescription = "",
                    FoodCalories = 600,
                    FoodCategory = meats
                });
                
                context.Foods.Add(new Food()
                {
                    FoodName = "Beef Burgers",
                    ImageUrl = "/Images/burgers.jpg",
                    FoodDescription = "",
                    FoodCalories = 900,
                    FoodCategory = meats
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Chicken",
                    ImageUrl = "/Images/chicken.jpg",
                    FoodDescription = "",
                    FoodCalories = 300,
                    FoodCategory = meats
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Fried Chicken",
                    ImageUrl = "/Images/fried_chicken.jpg",
                    FoodDescription = "",
                    FoodCalories = 600,
                    FoodCategory = meats
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Bacon",
                    ImageUrl = "/Images/bacon.jpg",
                    FoodDescription = "",
                    FoodCalories = 200,
                    FoodCategory = meats
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Lamb",
                    ImageUrl = "/Images/lamb.jpg",
                    FoodDescription = "",
                    FoodCalories = 400,
                    FoodCategory = meats
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Apple",
                    ImageUrl = "/Images/apple.jpg",
                    FoodDescription = "",
                    FoodCalories = 80,
                    FoodCategory = fruit
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Banana",
                    ImageUrl = "/Images/banana.jpg",
                    FoodDescription = "",
                    FoodCalories = 120,
                    FoodCategory = fruit
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Orange",
                    ImageUrl = "/Images/orange.jpg",
                    FoodDescription = "",
                    FoodCalories = 60,
                    FoodCategory = fruit
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Grapes",
                    ImageUrl = "/Images/grapes.jpg",
                    FoodDescription = "",
                    FoodCalories = 10,
                    FoodCategory = fruit
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Strawberry",
                    ImageUrl = "/Images/strawberries.jpg",
                    FoodDescription = "",
                    FoodCalories = 30,
                    FoodCategory = fruit
                });
                context.Foods.Add(new Food()
                {
                    FoodName = "Watermelon",
                    ImageUrl = "/Images/watermelon.jpg",
                    FoodDescription = "",
                    FoodCalories = 120,
                    FoodCategory = vegtables
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Carrots",
                    ImageUrl = "/Images/carrot.jpg",
                    FoodDescription = "",
                    FoodCalories = 120,
                    FoodCategory = vegtables
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Broccoli",
                    ImageUrl = "/Images/broccoli.jpg",
                    FoodDescription = "",
                    FoodCalories = 120,
                    FoodCategory = vegtables
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Spinach",
                    ImageUrl = "/Images/spinach.jpg",
                    FoodDescription = "",
                    FoodCalories = 120,
                    FoodCategory = vegtables
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Cabbage",
                    ImageUrl = "/Images/cabbage.jpg",
                    FoodDescription = "",
                    FoodCalories = 120,
                    FoodCategory = vegtables
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Onion",
                    ImageUrl = "/Images/onion.jpg",
                    FoodDescription = "",
                    FoodCalories = 120,
                    FoodCategory = vegtables
                });

                context.Foods.Add(new Food()
                {
                    FoodName = "Red Pepper",
                    ImageUrl = "/Images/peppers.jpg",
                    FoodDescription = "",
                    FoodCalories = 120,
                    FoodCategory = vegtables
                });



                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var chris = new ApplicationUser
                {
                    UserName = "chris@gmail.com",
                    Email = "chris@gmail.com",
                    EmailConfirmed = true,
                };

                userManager.Create(chris, "member");
                context.SaveChanges();

                var firstDay = new DailyCalorieCount
                {
                    IntakeDate = DateTime.Now,
                    User = chris,
                    TotalDailyCalories = 2200
                };

                context.DailyCalorieCounts.Add(firstDay);
                context.SaveChanges();

            }

        }

        
    }
}