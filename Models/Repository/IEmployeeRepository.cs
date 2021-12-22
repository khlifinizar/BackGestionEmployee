using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAPI.Models.Repository
{
  public  interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int employeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> updateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int employeeId);
        Task<Employee> GetEmployeeByEmail(string email);
    }
}
