using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.BL.Services.Interfaces;
using FifaPSL.Common.Models;
using FifaPSL.DAL.Repositories.Interfaces;
using FifaPSL.DAL;

namespace FifaPSL.BL.Services.Implementation
{
    public class GroupService: BaseService, IGroupService
    {

        public GroupService(IFifaRepository _fifaRepository) : base(_fifaRepository) {
        }

        public Group[] GetGroups()
        {
            group[] myGroups = fifaRepository.GetGroups();

            Group[] response = new Group[myGroups.Length];

            for (int i = 0; i < myGroups.Length; i++) {
                response[i] = new Group();
                response[i].id = myGroups[i].group_id;
                response[i].name = myGroups[i].name;
                response[i].tournament_id = myGroups[i].tournament_id;
            }

            return response;
            
        }
    }
}
