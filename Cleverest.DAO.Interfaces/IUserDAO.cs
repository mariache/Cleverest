using Cleverest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.DAO.Interfaces
{
    public interface IUserDAO
    {
        bool Add(User user);
        bool Remove(string id);
        string GetUserId(string login);
        bool UpdateInformation(string login, UserInformationObject info);
        bool AddInformation(string id);
        UserInformationObject GetUserInformation(string id);
        IEnumerable<User> GetAllByRole(string role);
    }
}
