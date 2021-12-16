using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using safetyModel = MyApp.Model;

namespace MyApp.Db.DbOperations
{
   public class EmployeeRepository
    {
        public int AddEmployee(safetyModel.Employee employee)
        {
            using (var context = new EmployeeDbEntities())
            {
                Employee em = new Employee {

                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Code = employee.Code,
                    Address = new Address
                      {
                          Details = employee.Address.Details,
                          Country =employee.Address.Country,
                          State = employee.Address.State
                      }
                    };
                context.Employees.Add(em);
                context.SaveChanges();

                return em.Id;
            }
        }

        public List<safetyModel.Employee> GetAllEmployees()
        {
            using (var context = new EmployeeDbEntities())
            {
               var result = context.Employees.Select(x=> new safetyModel.Employee { 
                  Id = x.Id ,
                 
                  Code = x.Code,
                  Email =x.Email,
                  FirstName = x.FirstName,
                  LastName = x.LastName,
                  Address =x.AddressId!= null ? new safetyModel.Address
                   {
                       Id = x.Address.Id,
                       Details = x.Address.Details,
                       Country = x.Address.Country,
                       State = x.Address.State
                   } : null

               }).ToList();

                return result;
            }
        }

        public safetyModel.Employee GetEmpRecord(int Id)
        {
            using (var context = new EmployeeDbEntities())
            {
                var result = context.Employees.Where(x=>x.Id==Id).Select(x => new safetyModel.Employee
                {
                    Id = x.Id,

                    Code = x.Code,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.AddressId != null ? new safetyModel.Address
                    {
                        Id = x.Address.Id,
                        Details = x.Address.Details,
                        Country = x.Address.Country,
                        State = x.Address.State
                    } : null

                }).FirstOrDefault();

                return result;
            }
        }

        public bool UpdateEmpoyee(safetyModel.Employee model)
        {
            var response = false;
            using (var cntxt = new EmployeeDbEntities())
            {
                var rec = cntxt.Employees.Where(x => x.Id == model.Id).FirstOrDefault();
                rec.FirstName = model.FirstName;
                rec.Code = model.Code;
                rec.Email = model.Email;
                rec.LastName = model.LastName;
                rec.AddressId = model.AddressId;

               response = cntxt.SaveChanges() > 0 ? true :false;
            }

            return response;
        }

        public bool DeleteEmployee(int? Id)
        {
            using (var context = new EmployeeDbEntities())
            {
                var emprec = context.Employees.Where(x => x.Id == Id).FirstOrDefault();
                if (emprec !=null)
                {
                    context.Employees.Remove(emprec);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
