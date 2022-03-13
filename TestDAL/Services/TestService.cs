using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDAL.Models;
using TestDTO;

namespace TestDAL
{
    public class TestService : ITestService
    {
        /// <summary>
        /// Get All employess
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployes()
        {
            using (var context = new TestContext())
            {
                return context.Employee.ToList();
            }
        }
        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="model"></param>
        public void AddEmployee(Employee model)
        {
            using (var context = new TestContext())
            {
                model.Doj = DateTime.Now;
                context.Employee.Add(model);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="model"></param>
        public void UpdateEmployee(Employee model)
        {
            using (var context = new TestContext())
            {
                var res = context.Employee.FirstOrDefault(a => a.Id == model.Id);
                if (res != null)
                {
                    res.Fname = model.Fname;
                    res.Lname = model.Lname;
                    res.Email = model.Email;
                    res.Doj = model.Doj;
                    context.Employee.Update(res);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteEmployee(int Id)
        {
            using (var context = new TestContext())
            {
                var res = context.Employee.FirstOrDefault(a => a.Id == Id);
                if (res != null)
                {
                    context.Employee.Remove(res);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Add Deptartment
        /// </summary>
        /// <param name="model"></param>
        public void AddDept(Dept model)
        {
            using (var context = new TestContext())
            {
                using (var cnn = context.Database.GetDbConnection())
                {
                    var cmm = cnn.CreateCommand();
                    cmm.CommandType = System.Data.CommandType.StoredProcedure;
                    cmm.CommandText = "[dbo].[UspAddDept]";
                    cmm.Connection = cnn;

                    SqlParameter name = new SqlParameter();
                    name.ParameterName = "@Name";
                    name.Value = model.Name;
                    cmm.Parameters.Add(name);

                    cnn.Open();
                    cmm.ExecuteNonQuery();
                }
            }
        }
    }
}
