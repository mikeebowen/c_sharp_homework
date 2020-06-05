using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayCard.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayCard.Controllers
{
    public class DefaultController : Controller
    {
        private bool creating = true;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(BirthdayMessage birthdayMessage)
        {
            if (ModelState.IsValid && creating)
            {
                creating = !creating;
                return View(birthdayMessage);
            }
            if (!creating)
            {
                creating = !creating;
                ModelState.Clear();
                return View();
            }
            return View();
        }
    }
}