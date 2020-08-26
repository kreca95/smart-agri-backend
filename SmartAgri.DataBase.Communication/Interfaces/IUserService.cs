using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        bool Register(User user);
        List<User> GetUsers();
        User GetUser(int id);
        bool UpdateUser(User user);
        User GetHashAndSalt(string email);
    }
}
