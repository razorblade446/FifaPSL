using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaPSL.DAL.Repositories.Interfaces
{
    interface ISecurityRepository
    {

        user getUser(string user_name);

        bool setUserPassword(int user_id, string password, string salt);
        
    }
}
