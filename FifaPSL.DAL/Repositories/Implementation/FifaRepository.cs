using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.DAL.Repositories.Interfaces;

namespace FifaPSL.DAL.Repositories.Implementation
{
    public class FifaRepository : IFifaRepository
    {

        private FifaDataSource _dbContext;

        public FifaRepository() {
            _dbContext = new FifaDataSource();
        }

        public tournament[] GetAllTournaments()
        {
            var tournamentsQuery = from t in _dbContext.tournament
                                   orderby t.tournament_id
                                   select t;

            List<tournament> tournaments = new List<tournament>();
            foreach(tournament item in tournamentsQuery) {
                tournaments.Add(item);
            }

            return tournaments.ToArray();
        }

        public tournament GetTournament(int tournamentId)
        {
            var tournamentIdCompare = new byte[] { (byte)tournamentId };

            var myTournament = _dbContext.tournament.First(t => t.tournament_id == (byte)tournamentId);

            return myTournament;

        }
    }
}
