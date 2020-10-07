using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.Entities
{
    public class Question
    {
        public string Id { get; set; }
        public string TestId { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public string VarA { get; set; }
        public string VarB { get; set; }
        public string VarC { get; set; }
        public string VarD { get; set; }
        public string Answer { get; set; }

        
    }
}
