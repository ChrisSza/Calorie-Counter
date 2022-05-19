using Calorie_Counter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calorie_Counter.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        [HttpGet]

        public ActionResult Contact() { return View(); }

        [HttpPost]
        public ActionResult Contact (Message message) { 
            
            if(ModelState.IsValid)
            {
                message.DateofMessage = DateTime.Now;
                context.Messages.Add(message);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message); 
        }
        
        public ActionResult SplashScreen()
        {

            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }
        public ActionResult Help()
        {
            return View();
        }

       
        public ActionResult Podcasts()
        {

            List<Podcasts> sounds = new List<Podcasts>();

            sounds.Add(new Podcasts { Name = "Ep 1- Intro", FilePath = "~/Sounds/Episode 1 Intro.mp3" });
            sounds.Add(new Podcasts { Name = "Ep 2- Planning Your first fast.mp3", FilePath = "~/Sounds/Episode 2 Planning your first fast.mp3" });
            sounds.Add(new Podcasts { Name = "Ep 3- Your Fast day Survival Guide", FilePath = "~/Sounds/Episode 3 Yourfastday survival guide.mp3" });
            sounds.Add(new Podcasts { Name = "Ep 4- What to eat on a Fast Day", FilePath = "~/Sounds/Ep4 What to Eat on a Fast Day.mp3" });
            sounds.Add(new Podcasts { Name = "Ep 5- How to love your food on non-fast days without over doing it", FilePath = "~/Sounds/Ep5 how to love your food on non-fast days without overdoing it.mp3" });
            sounds.Add(new Podcasts { Name = "Ep 6- Your flexible 5 2 diet", FilePath = "~/Sounds/Ep6 Your flexible 5 2 diet.mp3" });
            
            
           

            return View(sounds);
        }
    }
}