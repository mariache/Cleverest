using Cleverest.BLL.Interfaces;
using Cleverest.DAO.Interfaces;
using Cleverest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDAO _userDao;

        public UserLogic(IUserDAO userDao)
        {
            _userDao = userDao;
        }

        public bool Add(User user)
        {
            return _userDao.Add(user);
        }

        public User Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public string GetUserId(string login)
        {
            return _userDao.GetUserId(login);
        }

        public bool Remove(string id)
        {
            return _userDao.Remove(id);
        }

        public bool UpdateInformation(string login, UserInformationObject info)
        {
            return _userDao.UpdateInformation(login, info);
        }

        public bool AddInformation(string id)
        {
            return _userDao.AddInformation(id);
        }

        public UserInformationObject GetUserInformation(string id)
        {
            return _userDao.GetUserInformation(id);
        }

        public IEnumerable<User> GetAllByRole(string role)
        {
            return _userDao.GetAllByRole(role);
        }
    }
}
