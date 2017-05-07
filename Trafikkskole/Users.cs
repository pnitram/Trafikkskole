using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trafikkskole
{
    public class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int LastScore { get; set; }
        public int HighScore { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}