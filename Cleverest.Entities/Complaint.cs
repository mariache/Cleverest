using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.Entities
{
    public class Complaint
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }

        public Complaint() { }
        public Complaint(string text, string userId) 
        {
            Text = text;
            UserId = userId;
            Id = Guid.NewGuid().ToString();
        }
    }
}
