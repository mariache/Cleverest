using Cleverest.DAO.Enums;
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
    public class QuestionDAO : IQuestionDAO
    {
        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["CleverestDB"].ConnectionString;

        public bool Add(Question question)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(QuestionProcedures.AddQuestion.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@Id", question.Id),
                    new SqlParameter("@TestId", question.TestId),
                    new SqlParameter("@Topic", question.Topic),
                    new SqlParameter("@Text", question.Text),
                    new SqlParameter("@VarA", question.VarA),
                    new SqlParameter("@VarB", question.VarB),
                    new SqlParameter("@VarC", question.VarC),
                    new SqlParameter("@VarD", question.VarD),
                    new SqlParameter("@Answer", question.Answer)
                };

                command.Parameters.AddRange(param);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }
        public string GetAnswer(string questionId)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(QuestionProcedures.GetAnswer.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@Id", questionId));

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return reader["Answer"] as string;
                }

                return null;
            }
        }
        public IEnumerable<Question> GetQuestionsForTest(string testId)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(QuestionProcedures.GetQuestionsForTest.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@Id", testId));

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Question()
                    {
                        Id = reader["Id"] as string,
                        TestId = reader["TestId"] as string,
                        Topic = reader["Topic"] as string,
                        Text = reader["Text"] as string,
                        VarA = reader["VarA"] as string,
                        VarB = reader["VarB"] as string,
                        VarC = reader["VarC"] as string,
                        VarD = reader["VarD"] as string,
                        Answer = reader["Answer"] as string
                    };
                }
            }
        }
        public IEnumerable<Question> GetQuestionsByTopic(string topic)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(QuestionProcedures.GetQuestionsByTopic.ToString(), _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@Topic", topic));

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Question()
                    {
                        Id = reader["Id"] as string,
                        TestId = reader["TestId"] as string,
                        Topic = reader["Topic"] as string,
                        Text = reader["Text"] as string,
                        VarA = reader["VarA"] as string,
                        VarB = reader["VarB"] as string,
                        VarC = reader["VarC"] as string,
                        VarD = reader["VarD"] as string,
                        Answer = reader["Answer"] as string
                    };
                }
            }
        }

    }
}
