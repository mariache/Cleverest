using Cleverest.BLL.Interfaces;
using Cleverest.DAO.Interfaces;
using Cleverest.Entities;
using System.Collections.Generic;

namespace Cleverest.BLL
{
    public class QuestionLogic : IQuestionLogic
    {
        
        private readonly IQuestionDAO _questionDao;

        public QuestionLogic(IQuestionDAO questionDao)
        {
            _questionDao = questionDao;
        }

        public bool Add(Question question)
        {
            return _questionDao.Add(question);
        }

        public IEnumerable<Question> GetQuestionsForTest(string testId)
        {
            return _questionDao.GetQuestionsForTest(testId);
        }

        public string GetAnswer(string questionId)
        {
            return _questionDao.GetAnswer(questionId);
        }

        public IEnumerable<Question> GetQuestionsByTopic(string topic)
        {
            return _questionDao.GetQuestionsByTopic(topic);
        }
    }
}
