using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calorie_Counter.Models
{
    public class FoodCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name ="Category")]
        public string CategoryName { get; set; }

        public List<Food> Foods { get; set; }
    }
}