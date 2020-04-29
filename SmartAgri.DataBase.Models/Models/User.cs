using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Models.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }


        public Role Role { get; set; }

        public User()
        {
            Role = new Role();
        }
    }
}
