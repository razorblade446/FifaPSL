using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using FifaPSL.DAL.Repositories.Interfaces;
using FifaPSL.DAL.Repositories.Implementation;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace FifaPSL.DAL.Repositories
{
    public class Factory
    {

        public static UnityContainer container;

        protected static IDictionary<String,IBaseRepository> _repositories; 

        private static void initializeContainer() {
            if (container == null) {
                container = new UnityContainer();
                _repositories = new Dictionary<string, IBaseRepository>();

                container.RegisterType<ITournamentRepository, TournamentRepository>();
                container.RegisterType<IGroupRepository, GroupRepository>();
            }
        }

        static public T CreateInstance<T>()
        {
            String myType = typeof(T).ToString();
            initializeContainer();
            {
                if (!_repositories.ContainsKey(myType))
                {
                    _repositories.Add(myType, (IBaseRepository) container.Resolve<T>());
                }
                return (T) _repositories.GetOrNull(myType);
            }
        }

    }
}
