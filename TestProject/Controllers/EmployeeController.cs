using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDAL;
using TestDAL.Models;
using TestDTO;

namespace TestProject.Controllers
{
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        ITestService _service;
        public EmployeeController(ITestService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/[controller]/GetEmployees")]
        public List<Employee> GetEmployees()
        {
            return _service.GetAllEmployes();
        }

        [HttpPost]
        [Route("api/[controller]/AddEmployee")]
        public void AddEmployee(Employee model)
        {
            _service.AddEmployee(model);
        }

        [HttpPost]
        [Route("api/[controller]/AddDept")]
        public void AddDept(Dept model)
        {
            _service.AddDept(model);
        }
    }
}
