using Core.Entity;
using Implementation.Helper;
using Microsoft.Extensions.Configuration;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Implementation
{
    public class EmployeeImplementation : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeImplementation(IConfiguration configuration) {
            _connectionString = configuration.GetSection("ConnectionStrings:dbConnection").Value;
        }

        public async Task<bool> CreateEmployee(Employee model)
        {
            SqlParameter[] parameters =
             {
                new SqlParameter("@name", model.EmpName ?? string.Empty),
                new SqlParameter("@empcode", model.EmpCode ?? string.Empty),
                new SqlParameter("@gender", model.Gender ?? string.Empty),
                new SqlParameter("@department", model.DepartmentName ?? string.Empty),
                new SqlParameter("@salary", model.Salary),
            };

            var response = await SqlHelper.ExecuteNonQuery(_connectionString,
                SqlConstant.CreateEmployee, System.Data.CommandType.Text, parameters);

            return Convert.ToInt32(response) > 0;

        }

        public async Task<bool> DeleteEmployee(int id)
        {
            SqlParameter[] parameters = { 
                new SqlParameter("@Id", id) };

            var response = await SqlHelper.ExecuteNonQuery(_connectionString, SqlConstant.DeleteEmployee,
                System.Data.CommandType.Text, parameters);
            return Convert.ToInt32(response) > 0;

        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            List<Employee> models = new List<Employee>();
            var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.GetEmployee,
                System.Data.CommandType.Text, null);

            while (reader.Read())
            {
                Employee model = new Employee();
                model.Id = Convert.ToInt32(reader["Id"]);
                model.EmpName = reader["EmpName"].ToString();
                model.EmpCode = reader["EmpCode"].ToString();
                model.DepartmentName = reader["DepartmentName"].ToString();
                model.Gender = reader["Gender"].ToString();
                model.Salary = Convert.ToDecimal(reader["Salary"]);

                models.Add(model);
            }
            return models;
        }

        public Employee GetEmployeeById(int Id)
        {
            var model = new Employee();
            string selectCommand = @"Select Id,EmpName,EmpCode,Gender,DepartmentName,Salary from Employee where Id=@Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(selectCommand, con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", Id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        model.Id = Convert.ToInt32(reader["Id"]);
                        model.EmpName = (reader["EmpName"]).ToString();
                        model.EmpCode = (reader["EmpCode"]).ToString();
                        model.Gender = (reader["Gender"]).ToString();
                        model.DepartmentName = (reader["DepartmentName"]).ToString();
                        model.Salary = Convert.ToDecimal(reader["Salary"]);
                    }
                }
                return model;
            }
        }

        public async Task<bool> UpdateEmployee(Employee model)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@Id",model.Id),
                new SqlParameter("@empname", model.EmpName),
                new SqlParameter("@empcode", model.EmpCode),
                new SqlParameter("@gender", model.Gender),
                new SqlParameter("@department", model.DepartmentName),
                new SqlParameter("@salary", model.Salary),
            };
            var response = await SqlHelper.ExecuteNonQuery(_connectionString, SqlConstant.UpdateEmployee,
                System.Data.CommandType.Text, parameter);

            return Convert.ToInt32(response) > 0;
        }


    }
}