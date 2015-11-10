using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.BL.Services.Interfaces;
using FifaPSL.DAL.Repositories.Interfaces;
using FifaPSL.Common.Models;
using FifaPSL.DAL;
using Microsoft.Practices.Unity;

namespace FifaPSL.BL.Services.Implementation
{
    public class TournamentService : BaseService, ITournamentService
    {

        protected ITournamentRepository _tournamentRepository;
        protected IGroupRepository _groupRepository;

        [Dependency]
        public ITournamentRepository tournamentRepository
        {
            get { return _tournamentRepository; }
            set { _tournamentRepository = value; }
        }

        [Dependency]
        public IGroupRepository groupRepository
        {
            get { return _groupRepository; }
            set { _groupRepository = value; }
        }

        public Tournament[] getAllTournaments()
        {
            tournament[] myTournaments = _tournamentRepository.getTournaments();

            Tournament[] response = new Tournament[myTournaments.Length];

            for (int i = 0; i < myTournaments.Length; i++) {
                response[i] = new Tournament();
                response[i].id = myTournaments[i].tournament_id;
                response[i].name = myTournaments[i].name;
            }

            return response;
        }

        public Tournament getTournament(int tournamentId)
        {
            tournament myTournamentPrimitive = _tournamentRepository.getTournament(tournamentId);

            if(myTournamentPrimitive == null)
            {
                return null;
            }

            Tournament response = new Tournament();
            response.id = myTournamentPrimitive.tournament_id;
            response.name = myTournamentPrimitive.name;

            return response;
        }

        public Tournament getTournamentCurrent()
        {
            tournament myTournamentPrimitive = _tournamentRepository.getTournamentCurrent();

            if (myTournamentPrimitive == null)
            {
                return null;
            }

            Tournament response = new Tournament();
            response.id = myTournamentPrimitive.tournament_id;
            response.name = myTournamentPrimitive.name;

            return response;
        }

        public Group[] getTournamentGroups(int tournamentId)
        {
            int[] groupIds = _groupRepository.getGroupIdsByTournamentId(tournamentId);

            Group[] groups = new Group[groupIds.Length];

            GroupService groupService = ServiceFactory.container.Resolve<GroupService>();

            for (int i = 0; i < groupIds.Length; i++)
            {
                groups[i] = groupService.getGroup(groupIds[i]);
            }

            return groups;
        }

        public MatchDay[] getTournamentMatches(int tournamentId)
        {
            GetMatchesByTournamentId_Result[] matches = _tournamentRepository.getTournamentMatches(tournamentId);

            List<MatchDay> response = new List<MatchDay>();

            DateTime lastDate = new DateTime(
                2000,1,1);

            MatchDay currentMatchDay = null;
            List<Match> tempMatches = null;
            Match tempMatch = new Match();
            List<MatchUser> tempPlayers = new List<MatchUser>();

            int playerCount = 0;
            for (int i = 0; i < matches.Length; i++)
            {

                GetMatchesByTournamentId_Result matchPartial = matches[i];

                if (lastDate.Date != matchPartial.date_played.Value.Date)
                {
                    if (currentMatchDay != null)
                    {
                        // Next MachtDay
                        currentMatchDay.matches = tempMatches;
                        response.Add(currentMatchDay);
                    }
                    
                    // First Matchday
                        
                    currentMatchDay = new MatchDay();
                    currentMatchDay.date = matchPartial.date_played.Value.Date;
                    tempMatches = new List<Match>();

                    lastDate = matchPartial.date_played.Value.Date;
                }

                if (playerCount < 2)
                {
                    playerCount ++;

                    if (playerCount == 1)
                    {
                        tempMatch.date = matchPartial.date_played.Value;
                        tempMatch.id = matchPartial.match_id;
                        tempMatch.played = matchPartial.played;
                    }

                    MatchUser player = new MatchUser();
                    player.id = matchPartial.user_id;
                    player.Name = matchPartial.name;
                    player.local = matchPartial.local;
                    player.teamName = matchPartial.team_name;
                    player.teamFlag = matchPartial.team_flag;
                    player.score = matchPartial.score;
                    player.walk_over = matchPartial.walk_over;

                    tempPlayers.Add(player);

                    if (playerCount == 2)
                    {
                        tempMatch.Players = tempPlayers;
                        tempMatches.Add(tempMatch);

                        tempMatch = new Match();
                        tempPlayers = new List<MatchUser>();
                    }
                }

                if (i == matches.Length - 1)
                {
                    currentMatchDay.matches = tempMatches;
                    response.Add(currentMatchDay);
                }
            }

            return response.ToArray();

        }
    }
}
