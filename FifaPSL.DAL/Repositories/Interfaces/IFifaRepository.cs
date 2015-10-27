using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaPSL.DAL.Repositories.Interfaces
{
    public interface IFifaRepository
    {

        tournament[] GetAllTournaments();
        tournament GetTournament(int tournament_id);

    }
}
