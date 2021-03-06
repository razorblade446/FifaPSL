﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FifaPSL.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FifaDataSource : DbContext
    {
        public FifaDataSource()
            : base("name=FifaDataSource")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<group> group { get; set; }
        public virtual DbSet<league> league { get; set; }
        public virtual DbSet<match> match { get; set; }
        public virtual DbSet<match_type> match_type { get; set; }
        public virtual DbSet<match_user> match_user { get; set; }
        public virtual DbSet<team> team { get; set; }
        public virtual DbSet<team_league> team_league { get; set; }
        public virtual DbSet<team_user_group> team_user_group { get; set; }
        public virtual DbSet<tournament> tournament { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<user_auth> user_auth { get; set; }
        public virtual DbSet<user_group> user_group { get; set; }
    
        public virtual ObjectResult<GetMatchesByTournamentId_Result> GetMatchesByTournamentId(Nullable<byte> tournamentId, Nullable<System.DateTime> startingDate)
        {
            var tournamentIdParameter = tournamentId.HasValue ?
                new ObjectParameter("tournamentId", tournamentId) :
                new ObjectParameter("tournamentId", typeof(byte));
    
            var startingDateParameter = startingDate.HasValue ?
                new ObjectParameter("startingDate", startingDate) :
                new ObjectParameter("startingDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetMatchesByTournamentId_Result>("GetMatchesByTournamentId", tournamentIdParameter, startingDateParameter);
        }
    }
}
