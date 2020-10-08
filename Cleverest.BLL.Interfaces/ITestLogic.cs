using Cleverest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.BLL.Interfaces
{
    public interface ITestLogic
    {
        bool Add(Test test, string moderatorId);
        bool AddTestForCheck(Test test);
        Test GetTestForCheck(string id);
        bool Remove(string id);
        IEnumerable<Test> GetAll();
        Test GetById(string id);
        Test GetTestsByTopic(string topic);
        IEnumerable<Test> GetTestsForCheck();
        bool RemoveFromCheck(string id);
    }
}
