using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaPSL.Common.Models
{
    public class AuthenticationResponseModel
    {

        public User UserData { get; set; }
        public string Token { get; set; }

    }
}
