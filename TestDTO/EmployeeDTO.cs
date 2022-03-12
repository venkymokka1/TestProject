using System;

namespace TestDTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public DateTime? Doj { get; set; }
    }
}
