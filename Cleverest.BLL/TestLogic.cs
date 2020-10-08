using Cleverest.BLL.Interfaces;
using Cleverest.DAO.Interfaces;
using Cleverest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.BLL
{
    public class TestLogic : ITestLogic
    {
        private readonly ITestDAO _testDao;
        public TestLogic(ITestDAO testDao)
        {
            _testDao = testDao;
        }
        public bool Add(Test test, string moderatorId)
        {
           return _testDao.Add(test, moderatorId);
        }
        public IEnumerable<Test> GetAll()
        {
            return _testDao.GetAll();
        }
        public bool Remove(string id)
        {
            return _testDao.Remove(id);
        }
        public Test GetById(string id)
        {
            return _testDao.GetById(id);
        }
        public Test GetTestsByTopic(string topic)
        {
            return _testDao.GetTestsByTopic(topic);
        }
        public IEnumerable<Test> GetTestsForCheck()
        {
            return _testDao.GetTestsForCheck();
        }
        public bool AddTestForCheck(Test test)
        {
            return _testDao.AddTestForCheck(test);
        }
        public Test GetTestForCheck(string id)
        {
            return _testDao.GetTestForCheck(id);
        }
        public bool RemoveFromCheck(string id)
        {
            return _testDao.RemoveFromCheck(id);
        }
    }
}
