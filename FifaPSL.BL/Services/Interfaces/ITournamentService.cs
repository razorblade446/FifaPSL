using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.Common.Models;

namespace FifaPSL.BL.Services.Interfaces
{
    public interface ITournamentService
    {
        Tournament[] getAllTournaments();

        Tournament getTournament(int tournamentId);

        Tournament getTournamentCurrent();

        Group[] getTournamentGroups(int tournamentId);

        MatchDay[] getTournamentMatches(int tournamentId);
    }
}
