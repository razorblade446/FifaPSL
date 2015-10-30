﻿using System;
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
            tournamentService = (TournamentService)serviceFactory.GetTournamentService();
        }


        /// <summary>
        /// Get list of Tournaments
        /// </summary>
        /// <returns>Tournament list</returns>
        [Route("")]
        public IEnumerable<Tournament> GetTournaments()
        {
            return tournamentService.GetAllTournaments();
        }

        /// <summary>
        /// Get Tournament by ID
        /// </summary>
        /// <param name="tournamentId"></param>
        /// <returns></returns>
        [Route("{tournamentId:int}")]
        public Tournament GetTournament(int tournamentId) {

            Tournament myTournament = tournamentService.GetTournament(tournamentId);

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
        public IEnumerable<TournamentGroup> GetTournamentGroups(int tournamentId) {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Get all Matches for specific Tournament ID
        /// </summary>
        /// <param name="tournamentId"></param>
        /// <returns></returns>
        [Route("{tournamentId:int}/matches")]
        [HttpGet]
        public IEnumerable<Match> GetTournamentMatches(int tournamentId)
        {
            throw new NotImplementedException();
        }
    }
}
