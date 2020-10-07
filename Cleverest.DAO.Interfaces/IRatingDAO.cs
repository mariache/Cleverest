using Cleverest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.DAO.Interfaces
{
    public interface IRatingDAO
    {
        Dictionary<string, int> GetRating();
        Dictionary<string, int> GetTop(int count);
        bool AddUserToRating(string login);
        bool AddPoints(string login, int points);
    }
}
