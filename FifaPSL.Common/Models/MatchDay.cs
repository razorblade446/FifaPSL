using System;
using System.Collections.Generic;

namespace FifaPSL.Common.Models
{
    public class MatchDay
    {
        public DateTime date { get; set; }
        public IEnumerable<Match> matches { get; set; }
    }
}