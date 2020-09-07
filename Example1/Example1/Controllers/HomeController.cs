using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Example1.Models;  
using System.Linq;

namespace Example1.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            ViewBag.Greeting = hour + ":" + minute;
            ViewBag.Sultan = hour < 12 ? "Good Morning" : "Good Afternoon";
            if (hour < 12)
            {
                ViewBag.Massage = "Доброе утро";
            }
            else
            {
                ViewBag.Massage = "Добрый вечер";
            }
            return View("MyView");
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            Repasitory.AddResponse(guestResponse);
            return View("Thanks",guestResponse);
        }
        public ViewResult ListResponses() {
            return View(Repasitory.Responses.Where(r => r.WillAttend == true));
        }
    }
}
