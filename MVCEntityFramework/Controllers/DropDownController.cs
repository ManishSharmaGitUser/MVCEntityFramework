using MVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEntityFramework.Controllers
{
    public class DropDownController : Controller
    {
        // GET: DropDown
        public ActionResult Index()
        {
            //ViewBag.CList = new List<string>() { "India" ,"China" , "USA","Japan" };
            //Employee e = new Employee { Country = "India" };

            ViewBag.CList = new List<Country>() 
            {
                new Country {  Id = 1, Text="India"}, 
                new Country { Id = 2, Text = "China" }
            };

            return View();
        }

        [HttpPost]
        public ActionResult Index(Employee emp)
        {
            //ViewBag.CList = new List<string>() { "India", "China", "USA", "Japan" };

            ViewBag.CList = new List<Country>()
            {
                new Country {  Id = 1, Text="India"},
                new Country { Id = 2, Text = "China" }
            };

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}