using FirstWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebApi.Controllers
{
    [RoutePrefix("api/employee")]

    public class EmployeeController : ApiController
    {       
        List<Employee> empList = new List<Employee>()
        {
            //Bu Controller testi için WebApiConfig üzerinde routeTemplate => {action} ibaresini silmelisin. 

            new Employee{Id=1,Name="Emp1"},
            new Employee{Id=2,Name="Emp2"},
            new Employee{Id=3,Name="Emp3"}
        };

        [Route("")]
        public IEnumerable<Employee> Get()
        {
            return empList;
        }

        [Route("{id}")]
        public Employee Get(int id)
        {
            return empList.FirstOrDefault(e => e.Id == id);
        }

        [Route("{id}/tasks")]
        public IEnumerable<string> GetEmployeeTasks(int id) {
            switch (id)
            {
                case 1:
                    return new List<string> { "Task 1-1", "Task 1-2" };
                case 2:
                    return new List<string> { "Task 2-1", "Task 2-2" };
                case 3:
                    return new List<string> { "Task 3-1", "Task 3-2" };
                default:
                    return null;
            }
        }
    }
}
