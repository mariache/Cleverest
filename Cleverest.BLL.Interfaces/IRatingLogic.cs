using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.BLL.Interfaces
{
    public interface IRatingLogic
    {
        Dictionary<string, int> GetRating();
        Dictionary<string, int> GetTop(int count);
        bool AddUserToRating(string userId);
        bool AddPoints(string login, int points);
    }
}
