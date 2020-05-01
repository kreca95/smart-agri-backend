using SmartAgri.DataBase.Communication.Interfaces;
using SmartAgri.DataBase.Communication.Queries;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication.ServicesImplementations
{
    public class UserService : IUserService
    {
        private readonly NLog.Logger _logger;
        public UserService()
        {
            _logger = new NLogDb.NLogDB().GetLogger();
        }

        public bool Authenticate(string email, string password)
        {
            try
            {
                LoginUser loginUser = new LoginUser();
                User user = new User();
                user.Email = email;
                var hashsalt = GetHashAndSalt(email);
                var hash = hashsalt.Split(' ')[0];
                var salt = hashsalt.Split(' ')[1];
                return Hash.Validate(password, salt, hash);
            }
            catch (Exception e)
            {
                _logger.Error("Method called: {0}, Error message: {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                throw;
            }
            finally
            {
                _logger.Info("Method called: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public string GetHashAndSalt(string email)
        {
            try
            {
                Queries.GetHashAndSalt getHashAndSalt = new GetHashAndSalt();
                return getHashAndSalt.Execute(email);
            }
            catch (Exception e)
            {
                _logger.Error("Method called: {0}, Error message: {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                throw;
            }
            finally
            {
                _logger.Info("Method called: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
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
            try
            {
                InsertUser insertUser = new InsertUser();
                return insertUser.Execute(user);
            }
            catch (Exception e)
            {
                _logger.Error("Method called: {0}, Error message: {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                throw;
            }
            finally
            {
                _logger.Info("Method called: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
