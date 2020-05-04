using SmartAgri.DataBase.Communication.Interfaces;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.XUnit.Tests
{
    public class UserServiceMock : IUserService
    {
        private List<User> _users = new List<User>();
        public UserServiceMock()
        {
            _users.Add(new User { Id = 1, FirstName = "Kreso", LastName = "Sutalo",Email="kreso@kreso.ba" });
        }
        public bool Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public string GetHashAndSalt(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool Register(User user)
        {
            _users.Add(user);
            return _users.Count > 1;
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
