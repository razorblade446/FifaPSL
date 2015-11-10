using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.DAL.Repositories.Interfaces;

namespace FifaPSL.DAL.Repositories.Implementation
{
    public class TournamentRepository: BaseRepository, ITournamentRepository
    {
        public tournament[] getTournaments()
        {
            var tournamentsQuery = from t in _dbContext.tournament
                                   orderby t.tournament_id
                                   select t;

            tournament[] response = tournamentsQuery.ToArray();

            return response;
        }

        public tournament getTournament(int tournamentId)
        {
            var myTournament = _dbContext.tournament.FirstOrDefault(t => t.tournament_id == (byte)tournamentId);

            return myTournament;

        }

        public tournament getTournamentCurrent()
        {
            var mytournament =
                _dbContext.tournament.FirstOrDefault(t => t.start_date <= DateTime.Today && t.end_date >= DateTime.Today);

            return mytournament;
        }

        public GetMatchesByTournamentId_Result[] getTournamentMatches(int tournamentId)
        {
            var myMatches = _dbContext.GetMatchesByTournamentId((byte) tournamentId, null);

            GetMatchesByTournamentId_Result[] response = myMatches.ToArray();

            return response;
        }

    }
}
