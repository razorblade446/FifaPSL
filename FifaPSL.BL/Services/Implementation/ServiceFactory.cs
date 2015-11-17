using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Practices.Unity;
using FifaPSL.BL.Services.Interfaces;
using FifaPSL.DAL.Repositories.Interfaces;
using FifaPSL.DAL.Repositories.Implementation;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace FifaPSL.BL.Services.Implementation
{
    public class ServiceFactory : IServiceFactory
    {

        public static UnityContainer container;
        public static IDictionary<String, Object> _services; 

        public static void initialize() {
            if (container == null) {
                container = new UnityContainer();
                _services = new Dictionary<string, object>();

                container.RegisterType<ITournamentService, TournamentService>();
                container.RegisterType<IGroupService, GroupService>();
                container.RegisterType<ISecurityService, SecurityService>();

                container.RegisterType<ITournamentRepository, TournamentRepository>();
                container.RegisterType<IGroupRepository, GroupRepository>();
                container.RegisterType<ISecurityRepository, SecurityRepository>();

                container.RegisterType<RNGCryptoServiceProvider>(new InjectionConstructor());
            }
        }

        public static T GetService<T>()
        {
            string myType = typeof (T).ToString();
            initialize();
            if (!_services.ContainsKey(myType))
            {
                _services.Add(myType, container.Resolve<T>());
            }

            return (T) _services.GetOrNull(myType);
        }

    }
}
