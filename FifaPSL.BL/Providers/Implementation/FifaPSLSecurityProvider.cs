using System;
using System.Net.Http;
using FifaPSL.BL.Providers.Interfaces;
using FifaPSL.BL.Services.Interfaces;
using FifaPSL.Common.Models;
using Microsoft.Practices.Unity;

namespace FifaPSL.BL.Providers.Implementation
{
    /// <summary>
    /// Provides security functionality over webapi
    /// </summary>
    public sealed class FifaPSLSecurityProvider: IFifaPSLSecurityProvider
    {

        [Dependency]
        private ISecurityService SecurityService { get; set; }
        
        private static readonly FifaPSLSecurityProvider instance = new FifaPSLSecurityProvider();

        public static FifaPSLSecurityProvider Instance
        {
            get { return instance; }
        }

        private FifaPSLSecurityProvider()
        {

        }

        public bool SessionIsValid(string token)
        {
            return true;
        }
        
    }
}