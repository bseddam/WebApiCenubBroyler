using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCenubBroyler.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Sname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Gender { get; set; }
        public DateTime? Birthday { get; set; }
       
    }
}