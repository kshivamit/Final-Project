using Core.Entity.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entity
{
    public class Employee: BaseModel<int>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee Name is required.")]
        [MaxLength(200, ErrorMessage ="Employee name is too long.")]
        [MinLength(5,ErrorMessage ="Employee name is too short")]
        
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Employee Code is required.")]
        public string EmpCode { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Department Name is required.")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Employee picture is required.")]
        public string EmpImage { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        public decimal Salary { get; set; }
    }
}
