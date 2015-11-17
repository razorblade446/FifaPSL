using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.Common.Models;

namespace FifaPSL.BL.Providers.Interfaces
{
    public interface IFifaPSLSecurityProvider
    {
        bool SessionIsValid(string token);
    }
}
