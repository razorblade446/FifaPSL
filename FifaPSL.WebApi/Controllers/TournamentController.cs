using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FifaPSL.Common.Models;
using FifaPSL.BL.Services.Implementation;

namespace FifaPSL.WebApi.Controllers
{

    [RoutePrefix("tournament")]
    public class TournamentController : BaseController
    {

        protected static TournamentService tournamentService;

#pragma warning disable 1591
        public TournamentController(){
#pragma warning restore 1591
            tournamentService = (TournamentService) serviceFactory.GetTournamentService();
        } 

        [Route("all")]
        public IEnumerable<Tournament> GetTournaments()
        {
            return tournamentService.GetAllTournaments();
        }

        [Route("{tournamentId:int}")]
        public Tournament GetTournament(int tournamentId) {

            Tournament myTournament = tournamentService.GetTournament(tournamentId);

            if (myTournament == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return myTournament;
        }
    }
}
