using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.BL.Services.Interfaces;
using Microsoft.Practices.Unity;

namespace FifaPSL.BL.Services.Implementation
{
    class SecurityService: ISecurityService
    {

        private RNGCryptoServiceProvider _cryptProvider;

        [Dependency]
        public RNGCryptoServiceProvider cryptProvider
        {
            get { return _cryptProvider; }
            set { _cryptProvider = value; }
        }

        private SHA256Managed _cryptManager;

        [Dependency]
        public SHA256Managed cryptManager
        {
            get { return _cryptManager; }
            set { _cryptManager = value; }
        }

        class CryptoKey
        {
            public string salt { get; set; }
            public string hash { get; set; }
        }

        /*
        private byte[][] getCryptoKey(string password)
        {
            byte[] mySaltHash = new byte[32];
            byte[] myPasswordHash = Encoding.UTF8.GetBytes(password);

            cryptProvider.GetBytes(mySaltHash);
            cryptManager = new SHA256Managed();

            byte[] finalHash = cryptManager.ComputeHash(mySaltHash.Concat(myPasswordHash).ToArray(), 0, mySaltHash.Length + myPasswordHash.Length);

            byte[][] response = new byte[] { mySaltHash, myPasswordHash };}
        
        }*/
    }
}
