using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaPSL.Common.Models
{
    public class Team
    {
        public int teamId { get; set; }
        public string name { get; set; }
        public bool type { get; set; }
        public string code { get; set; }
    }
}
