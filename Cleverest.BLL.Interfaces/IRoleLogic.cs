using Cleverest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.BLL.Interfaces
{
    public interface IRoleLogic
    {
        string GetRole(string login);
        IEnumerable<User> GetAllByRole(string role);
        bool SetRole(string userId, string role);
    }
}
