using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationAPI.Models;
using WebApplicationAPI.Models.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest(); }
                else
                {
                    var createdEmployee = await employeeRepository.AddEmployee(employee);

                    return CreatedAtAction(nameof(GetEmployee),

                        new { id = createdEmployee.EmployeeId }, createdEmployee);

                }
                } 
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }
            }

        

        // PUT api/<EmployeesController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> updateEmployee(int id , Employee employee)
        {
            try
            {
                if (id != employee.EmployeeId)
                {
                    return BadRequest("Employee ID mismatch");
                }
                else
                {
                    var employeeToUpdate = await employeeRepository.GetEmployee(id);
                    if (employeeToUpdate == null)
                    {
                        return NotFound($"Employee with Id ={id} NotFound");
                    }
                    return await employeeRepository.updateEmployee(employee);

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }


        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = await employeeRepository.GetEmployee(id);
                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id ={id} not found ");
                }
                else
                {
                    return await employeeRepository.DeleteEmployee(id);
                }
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }


              
        }





        [HttpGet("{SearcheByEmail}")]
        public async Task<ActionResult<Employee>> GetEmployeeByEmail(string email)
        {
            try
            {
                var result = await employeeRepository.GetEmployeeByEmail(email);
                if (result == null)
                    return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
