using System;
using System.Collections.Generic;
using System.Text;
using TestDAL.Models;

namespace TestDAL
{
    public interface ITestService
    {
        List<Employee> GetAllEmployes();
        void AddEmployee(Employee model);
        void UpdateEmployee(Employee model);
        void DeleteEmployee(int Id);
        void AddDept(Dept model);
    }
}
