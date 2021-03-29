using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Data.Models
{
    public abstract class BaseModel
    {
        public string CreatedBy { get; set; }
    }
}
