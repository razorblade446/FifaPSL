using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.BL.Services.Interfaces;
using FifaPSL.DAL.Repositories.Interfaces;
using FifaPSL.Common.Models;
using FifaPSL.DAL;

namespace FifaPSL.BL.Services.Implementation
{
    public class TournamentService : BaseService, ITournamentService
    {

        public TournamentService(IFifaRepository _fifaRepository) : base(_fifaRepository) {
        }

        public Tournament[] GetAllTournaments()
        {
            tournament[] myTournaments = fifaRepository.GetAllTournaments();

            Tournament[] response = new Tournament[myTournaments.Length];

            for (int i = 0; i < myTournaments.Length; i++) {
                response[i] = new Tournament();
                response[i].id = myTournaments[i].tournament_id;
                response[i].name = myTournaments[i].name;
            }

            return response;
        }

        public Tournament GetTournament(int tournamentId)
        {
            tournament myTournamentPrimitive = fifaRepository.GetTournament(tournamentId);

            if(myTournamentPrimitive == null)
            {
                return null;
            }

            Tournament response = new Tournament();
            response.id = myTournamentPrimitive.tournament_id;
            response.name = myTournamentPrimitive.name;

            return response;
        }
    }
}
