using Cleverest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.DAO.Interfaces
{
    public interface ITestDAO
    {
        bool Add(Test test, string moderatorId);
        bool AddTestForCheck(Test test);
        bool Remove(string id);
        IEnumerable<Test> GetAll();
        Test GetById(string id);
        Test GetTestForCheck(string id);
        Test GetTestsByTopic(string topic);
        IEnumerable<Test> GetTestsForCheck();
        bool RemoveFromCheck(string id);

    }
}
