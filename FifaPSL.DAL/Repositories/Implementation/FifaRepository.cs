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

        public tournament[] GetTournaments()
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
            var myTournament = _dbContext.tournament.First(t => t.tournament_id == (byte)tournamentId);

            return myTournament;

        }

        public group[] GetGroups()
        {
            var groupsQuery = from g in _dbContext.@group
                              orderby g.tournament_id, g.group_id
                              select g;

            group[] groups = new group[groupsQuery.Count<group>()];
            int i = 0;
            foreach (group item in groupsQuery) {
                groups[i] = item;
                i++;
            }

            return groups;

        }

        public group[] GetGroupsByTournamentId(int tournamentId)
        {
            var groupsQuery = _dbContext.group.Where(g => g.tournament_id == (byte)tournamentId);

            return groupsQuery.ToArray();

        }

        public group GetGroup(int groupId)
        {
            var myGroup = _dbContext.group.First(g => g.group_id == groupId);

            return myGroup;
        }
    }
}
