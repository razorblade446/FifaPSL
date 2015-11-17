using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using FifaPSL.BL.Services.Interfaces;
using FifaPSL.Common.Models;
using FifaPSL.DAL;
using FifaPSL.DAL.Repositories.Interfaces;
using Microsoft.Practices.Unity;

namespace FifaPSL.BL.Services.Implementation
{
    public class SecurityService: ISecurityService
    {
        [Dependency]
        public RNGCryptoServiceProvider CryptProvider { get; set; }

        [Dependency]
        public SHA256Managed CryptManager { get; set; }

        [Dependency]
        public ISecurityRepository SecurityRepository { get; set; }

        public CryptoKey GetCryptoKey(string password)
        {
            byte[] mySaltHash = new byte[32];
            byte[] myPasswordHash = Encoding.UTF8.GetBytes(password);

            CryptProvider.GetBytes(mySaltHash);
            CryptManager = new SHA256Managed();

            byte[] hashedPassword = CryptManager.ComputeHash(mySaltHash.Concat(myPasswordHash).ToArray(), 0, mySaltHash.Length + myPasswordHash.Length);

            CryptoKey response = new CryptoKey();

            response.Salt = BitConverter.ToString(mySaltHash).Replace("-","");
            response.Hash = BitConverter.ToString(hashedPassword).Replace("-","");

            return response;
        
        }

        public UserAuth GetUserAuth(string userId)
        {
            user myUser = SecurityRepository.GetUser(userId);

            if (myUser != null)
            {
                UserAuth response = new UserAuth();
                response.id = myUser.user_id;
                response.name = myUser.name;
                response.Login = myUser.psl_id;
                response.Salt = myUser.salt;
                response.Password = myUser.password;

                return response;
            }
            else
            {
                return null;
            }
        }

        public string Login(AuthenticationRequestModel requestModel)
        {
            UserAuth userAuth = GetUserAuth(requestModel.Username);

            if (TestCryptoKey(requestModel.Password, new CryptoKey { Hash = userAuth.Password, Salt = userAuth.Salt }))
            {
                byte[] hToken = new byte[32];
                CryptProvider.GetBytes(hToken);
                string token = Convert.ToBase64String(hToken).Replace("=", "").Replace("+","").Replace("/","");

                if (SecurityRepository.SetUserToken(userAuth.id, token))
                {
                    return token;
                }
            }

            return null;
        }

        public bool TestCryptoKey(string password, CryptoKey criptoKey)
        {
            // 1. Hash password using CriptoKey Salt's

            byte[] passwordHash = Encoding.UTF8.GetBytes(password);
            byte[] saltHash = StringToByteArray(criptoKey.Salt);

            byte[] hashToTest = CryptManager.ComputeHash(saltHash.Concat(passwordHash).ToArray(), 0, saltHash.Length + passwordHash.Length);

            string hashStringToTest = BitConverter.ToString(hashToTest).Replace("-","");

            return criptoKey.Hash == hashStringToTest;

        }

        public IEnumerable<User> GetUserList()
        {
            List<User> response = new List<User>();

            IEnumerable<user> myUserList = SecurityRepository.GetUserList();

            foreach (user myUser in myUserList)
            {
                User myNewUser = new User();
                myNewUser.id = myUser.user_id;
                myNewUser.name = myUser.name;

                response.Add(myNewUser);
            }

            return response;
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}
