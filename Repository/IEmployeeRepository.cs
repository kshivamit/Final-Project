using Core.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IEmployeeRepository
    {
        Task<bool> CreateEmployee(Employee model);
        Task<bool> DeleteEmployee(int id);
        Task<bool> UpdateEmployee(Employee model);
        Task<IEnumerable<Employee>> GetEmployee();
        Employee GetEmployeeById(int id);
    }
}
