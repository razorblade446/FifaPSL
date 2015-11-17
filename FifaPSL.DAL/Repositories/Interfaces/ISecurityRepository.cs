using System.Collections.Generic;

namespace FifaPSL.DAL.Repositories.Interfaces
{
    public interface ISecurityRepository
    {

        user GetUser(string userName);

        IEnumerable<user> GetUserList(); 

        bool SetUserPassword(int userId, string password, string salt);

        bool SetUserToken(int userId, string token);

    }
}
