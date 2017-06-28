using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Project78.Models
{
    class User
    {
        public User(int id, string email, string fname, string lname, string pw)
        {
            ID = id;
            Email = email;
            FirstName = fname;
            LastName = lname;
            Password = pw;
        }

        public User(string email, string fname, string lname, string pw)
        {
            Email = email;
            FirstName = fname;
            LastName = lname;
            Password = pw;
        }

        [JsonProperty(PropertyName = "ID")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "LastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }
    }
}
