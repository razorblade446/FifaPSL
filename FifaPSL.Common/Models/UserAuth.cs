using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaPSL.Common.Models
{
    public class UserAuth: User
    {
        public string Login { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
    }
}
