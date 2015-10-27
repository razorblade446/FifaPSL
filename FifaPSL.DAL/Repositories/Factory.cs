using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using FifaPSL.DAL.Repositories.Interfaces;
using FifaPSL.DAL.Repositories.Implementation;

namespace FifaPSL.DAL.Repositories
{
    public class Factory
    {

        public static UnityContainer container;

        private static void initializeContainer() {
            if (container == null) {
                container = new UnityContainer();
                container.LoadConfiguration();
            }
        }

        static public IFifaRepository CreateInstance() {
            initializeContainer();
            return container.Resolve<IFifaRepository>();
        }

    }
}
