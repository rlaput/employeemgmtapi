using EmployeeManagement.Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> ListEmployees();
        Task<EmployeeDTO> GetEmployee(int id);
        Task CreateOrUpdateEmployee(EmployeeDTO employee);
    }
}
