using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Calorie_Counter.Models
{
    public class Food
    {
       
        public int FoodId { get; set; }

        [Display(Name= "Food")]
        public string FoodName { get; set; }

        [Display(Name ="Description")]

        public string FoodDescription { get; set; }

        [Display(Name ="Calories")]
        
        public int FoodCalories { get; set; }

        public string FoodType { get; set; }

        [Display(Name ="Image")]

        public string ImageUrl { get; set; }

        [ForeignKey("FoodCategory")]
        public int FoodCategoryId { get; set; }
        public FoodCategory FoodCategory { get; set; }


    }
    public enum Foodtype { Dairy, Fruit, Meat, Vegtables }
    
}