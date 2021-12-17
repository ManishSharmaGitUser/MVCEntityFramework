using MyApp.Db.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEntityFramework.Controllers
{
    public class PartialViewController : Controller
    {
        private readonly EmployeeRepository repo = null;

        public PartialViewController()
        {
            repo = new EmployeeRepository();
        }
        // GET: PartialView
        public ActionResult Index()
        {
            var emps = repo.GetAllEmployees();
            return View(emps);
        }
    }
}