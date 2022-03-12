using System;
using System.Collections.Generic;
using System.Text;
using TestDAL.Models;
using TestDTO;

namespace TestDAL
{
    public class TestService
    {
        public IEnumerable<EmployeeDTO> GetAllEmployes()
        {
            using (var context = new TestContext())
            {
                return context.Employee.AsQueryable() as IEnumerable<EmployeeDTO>;
            }
        }

        public void AddEmployee(Employee model)
        {
            using (var context = new TestContext())
            {
                model.Doj = DateTime.Now;
                context.Employee.Add(model);
                context.SaveChanges();
            }
        }

        //public void UpdateEmployee(Employee model)
        //{
        //    using (var context = new TestContext())
        //    {
        //        // var res = context.Employee.(a => a.id == model.Id).fi
        //        context.Employee.Update(model);
        //        context.SaveChanges();
        //    }
        //}



        //public void DeleteEmployee(int Id)
        //{
        //    using (var context = new TestContext())
        //    {
        //        var res = context.Employee;
        //        context.Employee.Remove(res);
        //        context.SaveChanges();
        //    }
        //}
    }
}
