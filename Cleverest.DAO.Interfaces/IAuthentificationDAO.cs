using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.DAO.Interfaces
{
    public interface IAuthentificationDAO
    {
        bool CanLogin(string login, string password);
        bool AvailableLogin(string login);
    }
}
