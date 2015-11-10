using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaPSL.Common.Models
{
    public class MatchUser: User
    {
        public bool local { get; set; }
        public string teamName { get; set; }
        public string teamFlag { get; set; }
        public int score { get; set; }
        public bool win { get; set; }
        public bool walk_over { get; set; }
    }
}
