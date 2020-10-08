using Cleverest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.DAO.Interfaces
{
    public interface IComplaintDAO
    {
        bool Add(Complaint complaint);
        IEnumerable<Complaint> GetAll();
        bool Remove(string id);
    }
}
