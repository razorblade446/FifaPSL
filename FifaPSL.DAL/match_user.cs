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
    using System.Collections.Generic;
    
    public partial class match_user
    {
        public int match_user_id { get; set; }
        public int match_id { get; set; }
        public short user_id { get; set; }
        public bool local { get; set; }
        public Nullable<short> team_id { get; set; }
        public byte score { get; set; }
        public bool win { get; set; }
        public bool walk_over { get; set; }
    
        public virtual match match { get; set; }
        public virtual user user { get; set; }
    }
}
