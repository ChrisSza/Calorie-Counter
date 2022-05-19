using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Calorie_Counter.Models
{
    public class DailyCalorieCount
    {
        [Key]
        public int DailyCalorieCountId { get; set; }

        [DataType(DataType.Date)]

        public DateTime IntakeDate { get; set; }

        public int TotalDailyCalories { get; set; }

        public void CalculateTotalDailyColories(int FoodCalories)
        {
            TotalDailyCalories = TotalDailyCalories + FoodCalories;
        }
        public void ResetTotalDailyCalories()
        {
            TotalDailyCalories = 0;
        }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

    }
}