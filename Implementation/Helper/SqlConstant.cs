using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Helper
{
    public static class SqlConstant
    {
        public static string CreateUser = @"Insert into Authenticate (UserName, Password, CreatedBy) 
                                           values(@UserName, @Password, 1)";
        public static string IsAuthenticate = @"Select Count(1) Password from Authenticate
                                             where UserName=@username and Password=@password and IsActive=1 and IsDeleted=0";

        public static string CreateEmployee = @"insert into Employee(EmpName, EmpCode, Gender, DepartmentName, Salary,CreatedBy) 
                                              values(@name, @empcode, @gender, @department, @salary, 1)";
        public static string UpdateEmployee = @"Update Employee SET EmpName=@empname, EmpCode=@empcode,
                                               DepartmentName=@department, Salary=@salary where Id=@Id";
        public static string DeleteEmployee  = @"Delete from Employee where Id=@Id";
        public static string GetEmployee = @"Select Id, EmpName, EmpCode, Gender, DepartmentName, Salary from Employee";
    }
}
