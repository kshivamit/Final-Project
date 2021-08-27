using Core.Entity;
using Implementation.Helper;
using Microsoft.Extensions.Configuration;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class AuthenticateImplementation : IAuthenticate
    {
        private readonly string _connectionString;
        public AuthenticateImplementation(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:dbConnection").Value;
        }
        public async Task<bool> CreateUser(AuthenticateModel model)
        {
            SqlParameter[] parameter =
            {
                new SqlParameter("@userName",model.UserName),
                new SqlParameter("@password",model.Password),
            };
            var response = await SqlHelper.ExecuteNonQuery(_connectionString, SqlConstant.CreateUser,
                System.Data.CommandType.Text, parameter);
            return Convert.ToInt32(response) > 0;
        }

        public async Task<bool> IsAuthenticate(AuthenticateModel model)
        {
            SqlParameter[] parameter =
            {
                new SqlParameter("@userName",model.UserName),
                new SqlParameter("@password",model.Password),
            };
            var response = await SqlHelper.ExecuteScalar(_connectionString, SqlConstant.IsAuthenticate,
                System.Data.CommandType.Text, parameter);
            return Convert.ToInt32(response) > 0;
        }
    }
}
