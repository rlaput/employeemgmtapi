using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Data.Models
{
    public class Employee : BaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNumber { get; set; }
    }
}
