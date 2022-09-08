using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using KKN_UKK.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using KKN_UKK.Models.User; 

namespace KKN_UKK.Helpers
{
    public class AccountHelpers
    {
        public string UserIdSessions = "_Id";
        public string NameSessions = "_Name";
        public string EmailSessions = "_Email";
        public string PhoneSessions = "_Phone";
        public string IsEmployeSessions = "_isEmploye";
        public string PhotoProfilPath = "_ProfilPath";

        DatabaseContextModels db = new DatabaseContextModels();

        public UserModels logins(string username, string password)
        {
           return db.M_Users.Where(s => s.Username == username && s.Password == password).FirstOrDefault();
        }

    }

    public static class Encryptor
    {
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }

    //public class UsersSession
    //{
    //    public string SessionsId = "_Id";
    //    public static string SessionsName = "_Name";
    //    public static string PhotoProfilPath = "_ProfilPath";
    //    public void SetUserSessions(UserModels model)
    //    {
    //        //HttpContext.
           
    //    }
    //}
}
