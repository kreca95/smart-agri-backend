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

        public User Authenticate(string email, string password)
        {
            try
            {
                LoginUser loginUser = new LoginUser();
                User user = new User
                {
                    Email = email
                };
                var userFromdb = GetHashAndSalt(email);
                var hash = userFromdb.PasswordHash;
                var salt = userFromdb.PasswordSalt;
                var check= Hash.Validate(password, salt, hash);
                if (check)
                {
                    return userFromdb;
                }
                return null;
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

        public User GetHashAndSalt(string email)
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
            try
            {
                GetAllUsers getAllUsers = new GetAllUsers();
                return getAllUsers.Execute();
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
