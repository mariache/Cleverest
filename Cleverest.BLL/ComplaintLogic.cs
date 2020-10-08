using Cleverest.BLL.Interfaces;
using Cleverest.DAO.Interfaces;
using Cleverest.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Cleverest.BLL
{
    public class ComplaintLogic : IComplaintLogic
    {
        private readonly IComplaintDAO _complaintDao;

        public ComplaintLogic(IComplaintDAO complaintDao)
        {
            _complaintDao = complaintDao;
        }
        public bool Add(Complaint complaint)
        {
            return _complaintDao.Add(complaint);
        }

        public IEnumerable<Complaint> GetAll()
        {
            return _complaintDao.GetAll();
        }

        public bool Remove(string id)
        {
            return _complaintDao.Remove(id);
        }
    }
}
