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
    }
}
