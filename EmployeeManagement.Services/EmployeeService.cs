using Dapper;
using EmployeeManagement.Data.DTO;
using EmployeeManagement.Data.Models;
using EmployeeManagement.Repo.Interfaces;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository _repository;
        public EmployeeService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateOrUpdateEmployee(EmployeeDTO employee)
        {
            if (employee.Id == 0)
            {
                await Task.FromResult(_repository.Execute(
                    $"INSERT INTO dbo.Employee(FirstName, MiddleName, LastName, EmployeeNumber, CreatedBy) " +
                    $"VALUES('{employee.FirstName}', '{employee.MiddleName}', '{employee.LastName}', '{employee.EmployeeBadgeNumber}', 'admin')",
                    null, commandType: CommandType.Text));
            }
            else
            {
                await Task.FromResult(_repository.Execute(
                    $"UPDATE dbo.Employee(FirstName, MiddleName, LastName, EmployeeNumber, CreatedBy) " +
                    $"SET FirstName='{employee.FirstName}', MiddleName='{employee.MiddleName}', LastName='{employee.LastName}', EmployeeNumber='{employee.EmployeeBadgeNumber}', 'admin'",
                    null, commandType: CommandType.Text));
            }
        }

        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            var result = await Task.FromResult(_repository.Get<Employee>($"SELECT * from dbo.Employee where Id = {id}", null, commandType: CommandType.Text));
            return new EmployeeDTO
            {
                EmployeeBadgeNumber = result.EmployeeNumber,
                FirstName = result.FirstName,
                Id = result.Id,
                LastName = result.LastName,
                MiddleName = result.MiddleName
            };
        }

        public async Task<IEnumerable<EmployeeDTO>> ListEmployees()
        {
            var result = await Task.FromResult(_repository.GetAll<Employee>($"SELECT * from dbo.Employee", null, commandType: CommandType.Text));
            return result.Select(q => new EmployeeDTO
            {
                EmployeeBadgeNumber = q.EmployeeNumber,
                FirstName = q.FirstName,
                Id = q.Id,
                LastName = q.LastName,
                MiddleName = q.MiddleName
            });
        }
    }
}
