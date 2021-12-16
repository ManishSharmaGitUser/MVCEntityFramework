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

        [HttpGet]
        public ActionResult GetAllEmployeesRecords()
        {
           List<safetymodel.Employee> emplist =  repo.GetAllEmployees();
           return View(emplist);
        }

        public ActionResult GetEmployeeRecord(int? Id)
        {
            dynamic record = null;
            if (Id!=null)
            {
                record = repo.GetEmpRecord(Id.Value);
                
            }
            return View(record);
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            dynamic record = null;
            if (Id != null)
            {
                record = repo.GetEmpRecord(Id.Value);

            }
            return View(record);
        }
        [HttpPost]
        public ActionResult Edit(safetymodel.Employee model)
        {

            bool result = repo.UpdateEmpoyee(model);
            if (result)
                return RedirectToAction("GetAllEmployeesRecords");
            else
                return View("Edit",model);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var result = repo.DeleteEmployee(Id);
            return RedirectToAction("GetAllEmployeesRecords");
        }
    }
}