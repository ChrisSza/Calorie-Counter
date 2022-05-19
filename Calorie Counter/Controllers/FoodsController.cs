using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calorie_Counter.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Calorie_Counter.Controllers
{
    public class FoodsController : Controller
    {

        private ApplicationDbContext context= new ApplicationDbContext();
        // GET: Food
        public ActionResult Index()
        {
            var foods = context.Foods.ToList();
            foreach (var item in foods)
            {
                context.Entry(item).Reload();
            }
            ViewBag.Categories =context.FoodCategories.ToList();

            string id = User.Identity.GetUserId();
            if (id != null)
            {
                DailyCalorieCount dailyCalorie = context.DailyCalorieCounts
                .Where(d=>DbFunctions.TruncateTime(d.IntakeDate)==DateTime.Today)
                .SingleOrDefault(d=>d.UserId.Equals(id));

                if (dailyCalorie != null)
                {
                    ViewBag.TotalCalorie = dailyCalorie.TotalDailyCalories;

                }
            }
            return View("FoodsView", foods);
        }
        public ActionResult Foods(int? id)
        {
            var foods = context.Foods.Where(p => p.FoodCategoryId == id);
            ViewBag.Categories = context.FoodCategories.ToList();

            string userId = User.Identity.GetUserId();

            if (userId != null)
            {
                DailyCalorieCount dailyCalorie = context.DailyCalorieCounts
                .Where(d => DbFunctions.TruncateTime(d.IntakeDate) == DateTime.Today)
                .SingleOrDefault(d => d.UserId.Equals(userId));

                if (dailyCalorie != null)
                {
                    ViewBag.TotalCalorie = dailyCalorie.TotalDailyCalories;
                }
            }
            return View("FoodsView", foods);
        }
        public ActionResult AddtoDailyCalories(int food)
        {
            UserManager<ApplicationUser>userManager=new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            string userId = userManager.FindByEmail(User.Identity.GetUserName()).Id;
            ApplicationUser user = context.Users.Find(userId);
            DailyCalorieCount dailyCalorie = context.DailyCalorieCounts
                .Where(d => DbFunctions.TruncateTime(d.IntakeDate) == DateTime.Today)
                .SingleOrDefault(d => d.User.Id.Equals(userId));

            if (dailyCalorie == null)
            {
                DailyCalorieCount dfi = new DailyCalorieCount
                {
                    IntakeDate = DateTime.Now.Date,
                    User = user
                };
                dfi.CalculateTotalDailyColories(food);
                context.DailyCalorieCounts.Add(dfi);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            DailyCalorieCount dailyClaorie2 = context.DailyCalorieCounts.Where(d => DbFunctions.TruncateTime(d.IntakeDate) == DateTime.Today).SingleOrDefault();

            dailyCalorie.CalculateTotalDailyColories(food);
            context.Entry(dailyCalorie).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ResetDailyCalories()
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            string userId = userManager.FindByEmail(User.Identity.GetUserName()).Id;
            ApplicationUser user = context.Users.Find(userId);
            DailyCalorieCount dailyClaorie = context.DailyCalorieCounts
                .Where(d => DbFunctions.TruncateTime(d.IntakeDate) == DateTime.Today)
                .SingleOrDefault(d => d.User.Id.Equals(userId));

            if (dailyClaorie == null)
            {
                DailyCalorieCount dfi = new DailyCalorieCount
                {
                    IntakeDate = DateTime.Now.Date,
                    User = user
                };
                dfi.ResetTotalDailyCalories();
                context.DailyCalorieCounts.Add(dfi);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            DailyCalorieCount dailyClaorie2 = context.DailyCalorieCounts.Where(d => DbFunctions.TruncateTime(d.IntakeDate) == DateTime.Today).SingleOrDefault();

            dailyClaorie.ResetTotalDailyCalories();
            context.Entry(dailyClaorie).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}