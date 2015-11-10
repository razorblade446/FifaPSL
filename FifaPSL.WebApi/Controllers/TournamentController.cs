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
        public TournamentController() {
#pragma warning restore 1591
            tournamentService = ServiceFactory.GetService<TournamentService>();
        }


        /// <summary>
        /// Get list of Tournaments
        /// </summary>
        /// <returns>Tournament list</returns>
        [Route("")]
        public IEnumerable<Tournament> GetTournaments()
        {
            return tournamentService.getAllTournaments();
        }


        /// <summary>
        /// Get current Tournament
        /// </summary>
        /// <returns>Tournament basic data</returns>
        [Route("current")]
        public Tournament GetTournamentCurrent()
        {
            return tournamentService.getTournamentCurrent();
        }

        /// <summary>
        /// Get Tournament by ID
        /// </summary>
        /// <param name="tournamentId"></param>
        /// <returns></returns>
        [Route("{tournamentId:int}")]
        public Tournament GetTournament(int tournamentId) {

            Tournament myTournament = tournamentService.getTournament(tournamentId);

            if (myTournament == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return myTournament;
        }


        /// <summary>
        /// Return Groups specific to Tournament ID
        /// </summary>
        /// <param name="tournamentId"></param>
        /// <returns></returns>
        [Route("{tournamentId:int}/groups")]
        [HttpGet]
        public IEnumerable<Group> GetTournamentGroups(int tournamentId)
        {
            return tournamentService.getTournamentGroups(tournamentId);
        }


        /// <summary>
        /// Get all Matches for specific Tournament ID
        /// </summary>
        /// <param name="tournamentId"></param>
        /// <returns></returns>
        [Route("{tournamentId:int}/matches")]
        [HttpGet]
        public IEnumerable<MatchDay> GetTournamentMatches(int tournamentId)
        {
            return tournamentService.getTournamentMatches(tournamentId);
        }
    }
}
