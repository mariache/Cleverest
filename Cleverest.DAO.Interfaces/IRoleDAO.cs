using Cleverest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.DAO.Interfaces
{
    public interface IRoleDAO
    {
        string GetRole(string login);
        IEnumerable<User> GetAllByRole(string role);
        bool SetRole(string userId, string role);
    }
}
