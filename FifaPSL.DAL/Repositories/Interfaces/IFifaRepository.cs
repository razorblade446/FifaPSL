using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaPSL.DAL.Repositories.Interfaces
{
    public interface IFifaRepository
    {

        tournament[] GetTournaments();
        tournament GetTournament(int tournamentId);

        group[] GetGroups();
        group[] GetGroupsByTournamentId(int tournamentId);
        group GetGroup(int groupId);

    }
}
