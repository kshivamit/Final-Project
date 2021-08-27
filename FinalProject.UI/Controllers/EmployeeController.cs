using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository;
using Core.Entity;

namespace FinalProject.UI.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _IEmployeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _IEmployeeRepository = employeeRepository;
        }

        public IActionResult Index(int Id)
        {
            if (Id == 0)
            {
                return View("~/Views/Employee/CreateEmployee.cshtml");
            }
            else
            {
                var response = _IEmployeeRepository.GetEmployeeById(Id);
                return View("~/Views/Employee/CreateEmployee.cshtml", response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee model)
        
        {

            if (model.Id == 0)
            {

                var response = await _IEmployeeRepository.CreateEmployee(model);
            }
            else
            {
                var response = await _IEmployeeRepository.UpdateEmployee(model);
            }
            return RedirectToAction("GetEmployee", "Employee");
        }
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            var response = await _IEmployeeRepository.DeleteEmployee(Id);
            return Json(response);
        }
        public async Task<IActionResult> GetEmployee()
        
        {
            var response = await _IEmployeeRepository.GetEmployee();
            return View("~/Views/Employee/EmployeeList.cshtml", response);
        }
    }
}
