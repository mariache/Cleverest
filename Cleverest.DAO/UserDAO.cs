using Cleverest.DAO.Enums.StoredProcedures;
using Cleverest.DAO.Interfaces;
using Cleverest.Entities;
using Cleverest.Entities.Enums;
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
    public class UserDAO : IUserDAO
    { 
        private static string _connectionString =
            ConfigurationManager.ConnectionStrings["CleverestDB"].ConnectionString;

        public bool Add(User user)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(UserProcedures.AddUser.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@Id", user.Id),
                    new SqlParameter("@Login", user.Login),
                    new SqlParameter("@Password", user.Password)
                };

                command.Parameters.AddRange(param);
                
                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }
        public bool Remove(string id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(UserProcedures.RemoveUser.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                var parameter = new SqlParameter(@"Id", id);

                command.Parameters.Add(parameter);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }
        public IEnumerable<User> GetAll()
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(UserProcedures.GetAllUsers.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    yield return new User
                    {
                        Id = reader["Id"] as string,
                        Login = reader["Login"] as string,
                        Password = reader["Password"] as string
                    };
                }
            }
        }
        public string GetUserId(string login)
        {
            using( var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(UserProcedures.GetUserId.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@Login", login));

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return reader["Id"] as string;
                }
                return null; 
            }
        }
        public bool UpdateInformation(string login, UserInformationObject info)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(UserProcedures.UpdateUserInformation.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@Login", login),
                    new SqlParameter("@Name", info.Name),
                    new SqlParameter("@Surname", info.Surname),
                    new SqlParameter("@Country", info.Country),
                    new SqlParameter("@About", info.About)
                };

                command.Parameters.AddRange(param);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }
        public bool AddInformation(string id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(UserProcedures.AddUserInformation.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@id", id));

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }
        public UserInformationObject GetUserInformation(string id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(UserProcedures.GetUserInformation.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@Id", id));

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new UserInformationObject()
                    {
                        Name = (reader["Name"] as string) ?? "",
                        Surname = (reader["Surname"] as string) ?? "",
                        Country = (reader["Country"] as string) ?? "",
                        About = (reader["About"] as string) ?? ""

                    };
                }
                return null;
            }
        }
        public IEnumerable<User> GetAllByRole(string role)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(UserProcedures.GetAllByRole.ToString(), _connection)
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
    }
}
