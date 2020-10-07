using Cleverest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.BLL.Interfaces
{
    public interface IQuestionLogic
    {
        bool Add(Question question);
        string GetAnswer(string questionId);
        IEnumerable<Question> GetQuestionsForTest(string testId);
        IEnumerable<Question> GetQuestionsByTopic(string topic);

    }
}
