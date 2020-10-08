using Cleverest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.BLL.Interfaces
{
    public interface IComplaintLogic
    {
        bool Add(Complaint complaint);
        IEnumerable<Complaint> GetAll();
        bool Remove(string id);
    }
}
