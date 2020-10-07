using Cleverest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.BLL.Interfaces
{
    public interface IUserLogic
    {
        bool Add(User user);
        bool Remove(string id);
        User Get();
        IEnumerable<User> GetAll();
        string GetUserId(string login);
        bool AddInformation(string id);
        bool UpdateInformation(string login, UserInformationObject info);
        UserInformationObject GetUserInformation(string id);
        IEnumerable<User> GetAllByRole(string role);


    }
}
