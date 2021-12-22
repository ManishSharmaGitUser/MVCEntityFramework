using MyApp.Db.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using safetymodel=MyApp.Model;
using System.Web.Security;

namespace MVCEntityFramework.Controllers
{
    public class AccountController : Controller
    {
        private readonly EmployeeRepository repo = null;
        public AccountController()
        {
            repo = new EmployeeRepository();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(safetymodel.User model)
        {
            bool isvalid = repo.ProcessLogin(model);
            if (isvalid)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                return RedirectToAction("GetAllEmployeesRecords", "Home");
            }
            ModelState.AddModelError("", "Invalid User Name");
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(safetymodel.User model)
        {
           bool result =  repo.ProcessSignUp(model);
           return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}