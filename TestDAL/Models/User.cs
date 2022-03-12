using System;
using System.Collections.Generic;

namespace TestDAL.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
