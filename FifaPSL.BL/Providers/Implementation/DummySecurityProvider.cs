using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.BL.Providers.Interfaces;
using FifaPSL.Common.Models;

namespace FifaPSL.BL.Providers.Implementation
{
    public class DummySecurityProvider: IFifaPSLSecurityProvider
    {
        public bool SessionIsValid(string token)
        {
            return true;
        }

        public string Login(AuthenticationRequestModel authModel)
        {
            throw new NotImplementedException();
        }
    }
}
