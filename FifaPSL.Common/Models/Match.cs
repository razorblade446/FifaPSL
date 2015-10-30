using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaPSL.Common.Models
{
    public class Match
    {
        public int matchId { get; set; }
        public int matchType { get; set; }
        public User localPlayer { get; set; }
        public int localScore { get; set; }
        public Team localTeam { get; set; }
        public User visitorPlayer { get; set; }
        public int visitorScore { get; set; }
        public Team visitorTeam { get; set; }
        public bool played { get; set; }
    }
}
