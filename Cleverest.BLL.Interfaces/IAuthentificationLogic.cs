using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.BLL.Interfaces
{
    public interface IAuthentificationLogic
    {
        bool CanLogin(string login, string password);
        bool AvailableLogin(string login);
    }
}
