using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.Common
{
    public class MyLogger : ILogger
    {
        public MyLogger()
        {
            Log4net.InitLogger();
        }

        public void Error(string message) => Log4net.Log.Error(message);

        public void Info(string message) => Log4net.Log.Info(message);
        
        public void Warning(string message) => Log4net.Log.Warn(message);
        
    }
}
