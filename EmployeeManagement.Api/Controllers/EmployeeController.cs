using EmployeeManagement.Data.DTO;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> Get()
        {
            return await _employeeService.ListEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<EmployeeDTO> Get(int id)
        {
            return await _employeeService.GetEmployee(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task Post([FromBody] EmployeeDTO employee)
        {
            await _employeeService.CreateOrUpdateEmployee(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] EmployeeDTO employee)
        {
            await _employeeService.CreateOrUpdateEmployee(employee);
        }
    }
}
