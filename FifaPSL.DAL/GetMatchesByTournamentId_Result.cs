//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FifaPSL.DAL
{
    using System;
    
    public partial class GetMatchesByTournamentId_Result
    {
        public int match_id { get; set; }
        public Nullable<System.DateTime> date_played { get; set; }
        public bool played { get; set; }
        public short user_id { get; set; }
        public string name { get; set; }
        public string team_name { get; set; }
        public string team_flag { get; set; }
        public byte score { get; set; }
        public bool local { get; set; }
        public bool walk_over { get; set; }
    }
}