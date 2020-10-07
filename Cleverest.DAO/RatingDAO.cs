using Cleverest.DAO.Enums.StoredProcedures;
using Cleverest.DAO.Interfaces;
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
    public class RatingDAO : IRatingDAO
    {
        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["CleverestDB"].ConnectionString;

        public bool AddUserToRating(string login)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(RatingProcedures.AddUserToRating.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@Login", login));

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }
        public Dictionary<string, int> GetRating()
        {
            var result = new Dictionary<string, int>();

            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(RatingProcedures.GetRating.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader["Login"] as string, (int)reader["Points"]);
                }
            }
            return result;
        }
        public bool AddPoints(string login, int points)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(RatingProcedures.AddPoints.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@Login", login),
                    new SqlParameter("@Points", points)
                };

                command.Parameters.AddRange(param);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }
        public Dictionary<string, int> GetTop(int count)
        {
            var result = new Dictionary<string, int>();

            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(RatingProcedures.GetTop.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@Counter", count));

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader["Login"] as string, (int)reader["Points"]);
                }
            }
            return result;
        }
    }
}
