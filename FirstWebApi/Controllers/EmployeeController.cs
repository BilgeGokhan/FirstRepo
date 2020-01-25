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
        static List<Employee> empList = new List<Employee>()
        {
            //Bu Controller testi için WebApiConfig üzerinde routeTemplate => {action} ibaresini silmelisin. 

            new Employee{Id=1,Name="EmpA"},
            new Employee{Id=2,Name="EmpB"},
            new Employee{Id=3,Name="EmpC"}
        };

        [Route("")]
        public IEnumerable<Employee> Get()
        {
            return empList;
        }

        [Route("{id:int}", Name = "GetById")] //Route Constraint Kullanımı parametre int olarak belirlenerek MultipleActions olması engelleniyor. 
        public Employee Get(int id)
        {
            return empList.FirstOrDefault(e => e.Id == id);
        }

        [Route("Add")]
        public HttpResponseMessage Post(Employee emp)
        {
            emp.Id = empList.Max(e => e.Id) + 1;

            empList.Add(emp);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            //response.Headers.Location = new Uri("/api/employee/" + emp.Id.ToString());
            //response.Headers.Location = new Uri(Request.RequestUri + "/" + emp.Id.ToString());
            response.Headers.Location = new Uri(Url.Link("GetById", new { id = emp.Id }));

            return response;
        }

        //Optional ve Default Route Kullanımı 2 şekil kullanımda aşağıda gösterilmiştir. 
        [Route("detail/{id:decimal?}")]
        public Employee Get(decimal id = 1)
        {
            return empList.FirstOrDefault(e => e.Id == id);
        }

        //[Route("{detail/id:decimal=1}")]
        //public Employee Get(decimal id)
        //{
        //    return empList.FirstOrDefault(e => e.Id == id);
        //}

        //Optional ve Default Route Kullanımı

        [Route("{name:alpha:lastletter}")] //Route Constraint Kullanımı parametre string olarak belirlenerek MultipleActions olması engelleniyor. 
        public Employee Get(string name)
        {
            return empList.FirstOrDefault(e => e.Name.ToLower() == name.ToLower());
        }

        [Route("{id}/tasks")]
        public IEnumerable<string> GetEmployeeTasks(int id)
        {
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

        [Route("~/api/tasks")] // Tilda işareti ile RoutePrefix i eziyoruz. 
        public IEnumerable<string> GetTasks()
        {
            return new List<string> { "Task 1-1", "Task 1-2", "Task 2-1", "Task 2-2", "Task 3-1", "Task 3-2" };
        }
    }
}
