using Cleverest.BLL.Interfaces;
using Cleverest.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.BLL
{
    public class RatingLogic : IRatingLogic
    {
        private readonly IRatingDAO _ratingDao;

        public RatingLogic(IRatingDAO ratingDao)
        {
            _ratingDao = ratingDao;
        }

        public bool AddPoints(string login, int points)
        {
            return _ratingDao.AddPoints(login, points);
        }

        public bool AddUserToRating(string userId)
        {
            return _ratingDao.AddUserToRating(userId);
        }

        public bool ChangeTop(string login)
        {
            throw new NotImplementedException();
        }

        public bool CheckForTop(string login)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> GetRating()
        {
            return _ratingDao.GetRating();
        }

        public Dictionary<string, int> GetTop(int count)
        {
            return _ratingDao.GetTop(count);
        }
    }
}
