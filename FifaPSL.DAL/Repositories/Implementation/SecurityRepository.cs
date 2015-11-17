using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using FifaPSL.DAL.Repositories.Interfaces;

namespace FifaPSL.DAL.Repositories.Implementation
{
    public class SecurityRepository: BaseRepository, ISecurityRepository
    {

        public user GetUser(string userName)
        {
            user myUser = _dbContext.user.FirstOrDefault(u => u.psl_id == userName);

            return myUser;
        }

        public IEnumerable<user> GetUserList()
        {
            List<user> userList = _dbContext.user.ToList();

            return userList.ToArray();
        }

        public bool SetUserPassword(int userId, string password, string salt)
        {
            user myUser = _dbContext.user.FirstOrDefault(u => u.user_id == userId);

            if (myUser == null)
            {
                return false;
            }

            myUser.password = password;
            myUser.salt = salt;

            return _dbContext.SaveChanges() > 0;

        }

        public bool SetUserToken(int userId, string token)
        {
            user_auth userAuth = new user_auth();

            if (userAuth == null)
            {
                return false;
            }

            userAuth.user_id = (byte) userId;
            userAuth.token = token;
            userAuth.issued = DateTime.Now;

            try
            {

                _dbContext.user_auth.Add(userAuth);
                _dbContext.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }
    }
}
