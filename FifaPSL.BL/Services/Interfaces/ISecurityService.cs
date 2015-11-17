using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.Common.Models;

namespace FifaPSL.BL.Services.Interfaces
{
    public interface ISecurityService
    {

        IEnumerable<User> GetUserList();

        CryptoKey GetCryptoKey(string password);

        UserAuth GetUserAuth(string userId);

        string Login(AuthenticationRequestModel requestModel);
    }
}
