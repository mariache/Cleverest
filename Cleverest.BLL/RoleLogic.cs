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
    public class RoleLogic : IRoleLogic
    {
        private readonly IRoleDAO _roleDao;

        public RoleLogic(IRoleDAO roleDao)
        {
            _roleDao = roleDao;
        }

        public IEnumerable<User> GetAllByRole(string role)
        {
            return _roleDao.GetAllByRole(role);
        }

        public string GetRole(string login)
        {
            return _roleDao.GetRole(login);
        }

        public bool SetRole(string userId, string role)
        {
            return _roleDao.SetRole(userId, role);
        }
    }
}
