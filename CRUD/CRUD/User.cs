using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    abstract class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public User(string id = "Per00", string name = "Per00", string email = "Per00", string pass = "Per00", string phone = "Per00")
        {
            ID = id;
            Name = name;
            Email = email;
            Password = pass;
            Phone = phone;
        }

        public override string ToString() =>
            $"ID : {this.ID}\nName : {this.Name}\nEmail : {this.Email}\nPhone : {this.Phone}";
    }
}
