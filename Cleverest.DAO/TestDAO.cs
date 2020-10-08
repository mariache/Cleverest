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
    public class TestDAO : ITestDAO
    {
        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["CleverestDB"].ConnectionString;

        public IEnumerable<Test> GetAll()
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(TestProcedures.GetAllTests.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {

                    yield return new Test
                    {
                        Id = reader["Id"] as string,
                        Name = reader["Name"] as string,
                        Topic = reader["Topic"] as string
                    };
                }
            }
        }
        public bool Add(Test test, string moderatorId)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(TestProcedures.AddTest.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@Id", test.Id),
                    new SqlParameter("@Name", test.Name),
                    new SqlParameter("@Topic", test.Topic),
                    new SqlParameter("@ModeratorId",moderatorId)
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
                var command = new SqlCommand(TestProcedures.RemoveTest.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@Id", id));

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }
        public Test GetById(string id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(TestProcedures.GetTestById.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@Id", id));

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new Test
                    {
                        Id = reader["Id"] as string,
                        Name = reader["Name"] as string,
                        Topic = reader["Topic"] as string
                    };
                }
                return null;
            }
        }
        public Test GetTestsByTopic(string topic)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(TestProcedures.GetTestsByTopic.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@Topic", topic));

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new Test
                    {
                        Id = reader["Id"] as string,
                        Name = reader["Name"] as string,
                        Topic = reader["Topic"] as string
                    };
                }
                return null;
            }
        }
        public IEnumerable<Test> GetTestsForCheck()
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(TestProcedures.GetTestsForCheck.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Test
                    {
                        Id = reader["Id"] as string,
                        Name = reader["Name"] as string,
                        Topic = reader["Topic"] as string
                    };
                }
            }
        }
        public bool AddTestForCheck(Test test)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(TestProcedures.AddTestForCheck.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@Id", test.Id),
                    new SqlParameter("@Name", test.Name),
                    new SqlParameter("@Topic", test.Topic)
                };

                command.Parameters.AddRange(param);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }
        public Test GetTestForCheck(string id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(TestProcedures.GetTestForCheck.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@Id", id));

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new Test
                    {
                        Id = reader["Id"] as string,
                        Name = reader["Name"] as string,
                        Topic = reader["Topic"] as string
                    };
                }
                return null;
            }
        }
        public bool RemoveFromCheck(string id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(TestProcedures.RemoveFromCheck.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@Id", id));

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }
    }
}
