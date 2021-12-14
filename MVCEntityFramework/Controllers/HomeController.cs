using MyApp.Db.DbOperations;
using safetymodel=MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEntityFramework.Controllers
{
    public class HomeController : Controller
    {
        EmployeeRepository repo = null;

        public HomeController()
        {
            repo = new EmployeeRepository();
        }
        // GET: Home
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(safetymodel.Employee model)
        {
            if (ModelState.IsValid)
            {
                int id = repo.AddEmployee(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Data Added";
                }
            }
            return View();
        }
    }
}