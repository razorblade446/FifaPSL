using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaPSL.Common.Models
{
    public class TournamentGroup: Group
    {
        public MatchUser[] MatchUsers { get; set; }
    }
}
