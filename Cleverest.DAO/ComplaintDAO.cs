using Cleverest.DAO.Enums.StoredProcedures;
using Cleverest.DAO.Interfaces;
using Cleverest.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Cleverest.DAO
{

    public class ComplaintDAO : IComplaintDAO
    {
        private static string _connectionString =
            ConfigurationManager.ConnectionStrings["CleverestDB"].ConnectionString;

        public bool Add(Complaint complaint)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(ComplaintProcedures.AddComplaint.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@Id", complaint.Id),
                    new SqlParameter("@Text", complaint.Text),
                    new SqlParameter("@UserId", complaint.UserId)
                };

                command.Parameters.AddRange(param);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public IEnumerable<Complaint> GetAll()
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(ComplaintProcedures.GetComplaints.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {

                    yield return new Complaint
                    {
                        Id = reader["Id"] as string,
                        Text = reader["Text"] as string,
                        UserId = reader["UserId"] as string
                    };
                }
            }
        }

        public bool Remove(string id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(ComplaintProcedures.RemoveComplaint.ToString(), _connection)
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
