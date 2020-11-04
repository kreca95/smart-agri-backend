using SportBook.Libraries.DBCommunication;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Models.Models
{
    public class User
    {
        public User()
        {
            Role = new Role();
        }
        public User(System.Data.IDataReader rdr)
        {
            PasswordHash = rdr.GetRecord<string>("password_hash");
            PasswordSalt = rdr.GetRecord<string>("password_salt");
            Id = rdr.GetRecord<int>("id");
            FirstName = rdr.GetRecord<string>("first_name");
            LastName = rdr.GetRecord<string>("last_name");
            Sex = rdr.GetRecord<string>("sex");
            Birthday = rdr.GetRecord<DateTime>("birthday");
            Email = rdr.GetRecord<string>("email");
            RoleId = rdr.GetRecord<int>("role_id");

            Role = new Role();
        }
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

    }
}
