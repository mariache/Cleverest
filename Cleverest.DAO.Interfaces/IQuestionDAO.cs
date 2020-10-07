using Cleverest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.DAO.Interfaces
{
    public interface IQuestionDAO
    {
        bool Add(Question question);
        IEnumerable<Question> GetQuestionsForTest(string testId);
        IEnumerable<Question> GetQuestionsByTopic(string topic);
        string GetAnswer(string questionId);
    }
}
