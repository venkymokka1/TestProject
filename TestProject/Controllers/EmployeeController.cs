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
        TestService _service = new TestService();

        [HttpGet]
        [Route("api/[controller]/GetEmployees")]
        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            var res = _service.GetAllEmployes();
            return _service.GetAllEmployes().AsEnumerable().ToArray();
        }

        [HttpPost]
        [Route("api/[controller]/AddEmployee")]
        public void AddEmployee(Employee model)
        {
            _service.AddEmployee(model);
        }
    }
}
