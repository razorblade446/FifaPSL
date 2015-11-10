using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.DAL.Repositories.Interfaces;

namespace FifaPSL.DAL.Repositories.Implementation
{
    public class GroupRepository: BaseRepository, IGroupRepository
    {
        
        public group getGroup(int groupId)
        {
            var myGroup = _dbContext.@group.FirstOrDefault(g => g.group_id == groupId);
            return myGroup;
        }

        public group[] getGroups()
        {
            var groupsQuery = from g in _dbContext.@group
                              orderby g.tournament_id, g.group_id
                              select g;

            group[] groups = groupsQuery.ToArray();

            return groups;

        }

        public int[] getGroupIdsByTournamentId(int tournamentId)
        {
            byte tId = Convert.ToByte(tournamentId);

            var tournamentGroupIdsQuery = from g in _dbContext.@group
                where g.tournament_id == tId
                select (int) g.group_id;

            int[] response = tournamentGroupIdsQuery.ToArray<int>();

            return response;
        }

    }
}
