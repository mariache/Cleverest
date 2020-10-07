using Cleverest.DAO.Enums.StoredProcedures;
using Cleverest.DAO.Interfaces;
using Cleverest.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Cleverest.DAO
{
    public class RoleDAO : IRoleDAO
    {
        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["CleverestDB"].ConnectionString;

        
        public string GetRole(string login)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(RoleProcedures.GetRole.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@Login", login));

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return reader["Role"] as string;
                }
                return null;
            }
        }
        public IEnumerable<User> GetAllByRole(string role)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(RoleProcedures.GetAllByRole.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@Role", role));

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User
                    {
                        Id = reader["Id"] as string,
                        Login = reader["Login"] as string,
                        Password = reader["Password"] as string,
                        Role = reader["Role"] as string
                    };
                }
            }
        }
        public bool SetRole(string userid, string role)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(RoleProcedures.SetRole.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                var param = new SqlParameter[]
                {
                    new SqlParameter("@Id", userid),
                    new SqlParameter("@Role", role)
                };

                command.Parameters.AddRange(param);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        
    }
}
