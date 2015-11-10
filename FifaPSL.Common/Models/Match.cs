using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaPSL.Common.Models
{
    public class Match
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public bool played { get; set; }
        public IEnumerable<MatchUser> Players { get; set; }
    }
}
