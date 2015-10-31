using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.BL.Services.Interfaces;
using FifaPSL.Common.Models;
using FifaPSL.DAL.Repositories.Interfaces;
using FifaPSL.DAL;
using Microsoft.Practices.Unity;

namespace FifaPSL.BL.Services.Implementation
{
    public class GroupService: BaseService, IGroupService
    {

        protected IGroupRepository _groupRepository;

        [Dependency]
        public IGroupRepository groupRepository
        {
            get { return _groupRepository; }
            set { _groupRepository = value; }
        }

        public Group[] getGroups()
        {
            group[] myGroups = _groupRepository.getGroups();

            Group[] response = new Group[myGroups.Length];

            for (int i = 0; i < myGroups.Length; i++) {
                response[i] = new Group();
                response[i].id = myGroups[i].group_id;
                response[i].name = myGroups[i].name;
                response[i].tournament_id = myGroups[i].tournament_id;
            }

            return response;
            
        }

        public Group getGroup(int groupId)
        {
            @group myGroup = _groupRepository.getGroup(groupId);

            if (myGroup == null)
            {
                return null;
            }

            Group response = new Group();
            response.tournament_id = myGroup.tournament_id;
            response.name = myGroup.name;
            response.id = myGroup.group_id;

            return response;
        }
    }
}
