using System;
using System.Collections.Generic;
using System.Text;

namespace Soons.Models
{
    class Users
    {
        public int id { get; set; }
        public int role { get; set; }
        public String email { get; set; }
        public String name { get; set; }
        public String surname { get; set; }
        public String password { get; set; }
        public String phone { get; set; }
        public DateTime birth { get; set; }
        public String sex { get; set; }
    }
}
