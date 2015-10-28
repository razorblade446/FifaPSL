﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using FifaPSL.BL.Services.Interfaces;
using FifaPSL.DAL.Repositories.Interfaces;
using FifaPSL.DAL.Repositories.Implementation;

namespace FifaPSL.BL.Services.Implementation
{
    public class ServiceFactory : IServiceFactory
    {

        public static UnityContainer container;

        protected static ITournamentService tournamentService;
        protected static IGroupService groupService;

        public ServiceFactory() {
            if (container == null) {
                container = new UnityContainer();

                container.RegisterType<ITournamentService, TournamentService>();
                container.RegisterType<IFifaRepository, FifaRepository>();
                container.RegisterType<IGroupService, GroupService>();
            }
        }

        public ITournamentService GetTournamentService()
        {
            if (tournamentService == null) {
                tournamentService = container.Resolve<ITournamentService>();
            }
            return tournamentService;
        }

        public IGroupService GetGroupService()
        {
            if (groupService == null) {
                groupService = container.Resolve<IGroupService>();
            }
            return groupService;
        }
    }
}
