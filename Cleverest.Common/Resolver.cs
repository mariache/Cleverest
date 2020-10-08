using Cleverest.BLL;
using Cleverest.BLL.Interfaces;
using Cleverest.DAO;
using Cleverest.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.Common
{
    public static class Resolver
    {
        private static readonly IUserLogic _userLogic;
        private static readonly IUserDAO _userDao;
        public static IUserLogic UserLogic => _userLogic;
        //public static IUserDAO UserDAO => _userDao;


        private static readonly ITestLogic _testLogic;
        private static readonly ITestDAO _testDao;
        public static ITestLogic TestLogic => _testLogic;
        //public static ITestDAO TestDAO => _testDao;


        private static readonly IQuestionLogic _questionLogic;
        private static readonly IQuestionDAO _questionDao;
        public static IQuestionLogic QuestionLogic => _questionLogic;
        //public static IQuestionDAO QuestionDAO => _questionDao;


        private static readonly IRatingLogic _ratingLogic;
        private static readonly IRatingDAO _ratingDao;
        public static IRatingLogic RatingLogic => _ratingLogic;
        //public static IRatingDAO RatingDAO => _ratingDao;


        private static readonly IAuthentificationLogic _authenticationLogic;
        private static readonly IAuthentificationDAO _authenticationDao;
        public static IAuthentificationLogic AuthentificationLogic => _authenticationLogic;
        //public static IAuthentificationDAO AuthentificationDAO => _authenticationDao;


        private static readonly IRoleLogic _roleLogic;
        private static readonly IRoleDAO _roleDao;
        public static IRoleLogic RoleLogic => _roleLogic;
        //public static IRoleDAO RoleDAO => _roleDao;

        private static readonly IComplaintLogic _complaintLogic; 
        private static readonly IComplaintDAO _complaintDao;
        public static IComplaintLogic ComplaintLogic => _complaintLogic;
        //public static IComplaintDAO ComplaintDAO => _complaintDao;


        private static readonly ILogger _logger;
        public static ILogger Logger => _logger;

        static Resolver()
        {
            _userDao = new UserDAO();
            _userLogic = new UserLogic(_userDao);

            _testDao = new TestDAO();
            _testLogic = new TestLogic(_testDao);

            _questionDao = new QuestionDAO();
            _questionLogic = new QuestionLogic(_questionDao);

            _ratingDao = new RatingDAO();
            _ratingLogic = new RatingLogic(_ratingDao);

            _authenticationDao = new AuthentificationDAO();
            _authenticationLogic = new AuthentificationLogic(_authenticationDao);

            _roleDao = new RoleDAO();
            _roleLogic = new RoleLogic(_roleDao);

            _complaintDao = new ComplaintDAO();
            _complaintLogic = new ComplaintLogic(_complaintDao);

            _logger = new MyLogger();

        }
    }
}
