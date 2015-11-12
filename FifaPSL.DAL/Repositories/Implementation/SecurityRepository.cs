using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.DAL.Repositories.Interfaces;
using System.Security.Cryptography;

namespace FifaPSL.DAL.Repositories.Implementation
{
    class SecurityRepository: BaseRepository, ISecurityRepository
    {

        public user getUser(string user_name)
        {
            user myUser = _dbContext.user.FirstOrDefault(u => u.psl_id == user_name);

            return myUser;
        }

        public bool setUserPassword(int user_id, string password, string salt)
        {
            user myUser = _dbContext.user.FirstOrDefault(u => u.user_id == user_id);

            if (myUser == null)
            {
                return false;
            }

            myUser.password = password;
            myUser.salt = salt;

            return _dbContext.SaveChanges() > 0;

        }
        
    }
}
