using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using FifaPSL.BL.Services.Interfaces;
using FifaPSL.DAL.Repositories.Interfaces;
using FifaPSL.DAL.Repositories.Implementation;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace FifaPSL.BL.Services.Implementation
{
    public class ServiceFactory : IServiceFactory
    {

        public static UnityContainer container;
        public static IDictionary<String, IBaseService> _services; 

        public static void initialize() {
            if (container == null) {
                container = new UnityContainer();
                _services = new Dictionary<string, IBaseService>();

                container.RegisterType<ITournamentService, TournamentService>();
                container.RegisterType<IGroupService, GroupService>();

                container.RegisterType<ITournamentRepository, TournamentRepository>();
                container.RegisterType<IGroupRepository, GroupRepository>();
            }
        }

        public static T GetService<T>()
        {
            string myType = typeof (T).ToString();
            initialize();
            if (!_services.ContainsKey(myType))
            {
                _services.Add(myType, (IBaseService) container.Resolve<T>());
            }

            return (T) _services.GetOrNull(myType);
        }

    }
}
