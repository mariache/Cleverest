using Cleverest.DAO.Enums.StoredProcedures;
using Cleverest.DAO.Interfaces;
using Cleverest.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.DAO
{
    public class AuthentificationDAO : IAuthentificationDAO
    {
        private static string _connectionString =
            ConfigurationManager.ConnectionStrings["CleverestDB"].ConnectionString;

        public bool AvailableLogin(string login)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(UserProcedures.AvailableLogin.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@Login", login)
                };

                command.Parameters.AddRange(param);

                _connection.Open();

                return !command.ExecuteReader().Read();
            }
        }

        public bool CanLogin(string login, string password)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(UserProcedures.CanLogin.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@Login", login),
                    new SqlParameter("@Password", password)
                };

                command.Parameters.AddRange(param);

                _connection.Open();

                return command.ExecuteReader().Read();
            }
        }
    }
}
