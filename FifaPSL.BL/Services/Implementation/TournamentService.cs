using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
