using Cleverest.BLL.Interfaces;
using Cleverest.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.BLL
{

    public class AuthentificationLogic : IAuthentificationLogic
    {
        private readonly IAuthentificationDAO _authentificationDao;

        public AuthentificationLogic(IAuthentificationDAO authentificationDao)
        {
            _authentificationDao = authentificationDao;
        }

        public bool AvailableLogin(string login)
        {
            return _authentificationDao.AvailableLogin(login);
        }

        public bool CanLogin(string login, string password)
        {
            return _authentificationDao.CanLogin(login, password);
        }

        
    }
}
