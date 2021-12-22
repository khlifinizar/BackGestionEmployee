using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBrith { get; set; }
        public Gender Gendre { get; set; }
        public int DepartementId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }
    }
}
