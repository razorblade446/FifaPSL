using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaPSL.Common.Models
{
    public class Player: User
    {
        public Team teamA { get; set; }
        public Team teamB { get; set; }
        public Team teamC { get; set; }
        public int gamesPlayed { get; set; }
        public int gamesWon { get; set; }
        public int gamesDraw { get; set; }
        public int gamesLost { get; set; }
        public int points { get; set; }
        public int goalsOwn { get; set; }
        public int goalsAgainst { get; set; }
    }
}
