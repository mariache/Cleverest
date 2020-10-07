using Cleverest.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Cleverest.Models
{
    public static class Container
    {
        public static string CurrentTestId { get; set; }
        public static Test CurrentTest { get; set; }
        public static string CurrentTestName { get; set; }
        public static Question[] CurrentQuestions {get; set;}
        public static int Score { get; set; }
        public static int Bonus { get; set; }

        
        public static  void Clear()
        {
            CurrentTestId = null;
            CurrentTestName = null;
            CurrentQuestions = null;
            CurrentTest = null;
            Score = 0;
            Bonus = 0;
        }


    }
}