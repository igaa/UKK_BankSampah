using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKN_UKK.Models;
using Newtonsoft.Json;
using KKN_UKK.Helpers;
using KKN_UKK.Models.Entity;
using Microsoft.AspNetCore.Http;
using KKN_UKK.Models.User; 

namespace KKN_UKK.Controllers
{

    public class AccountController : Controller
    {
     

        DatabaseContextModels db = new DatabaseContextModels();

        [HttpPost]
        public APIResponse Login([FromForm]LoginModels models)
        {
            List<FieldModels> forms = JsonConvert.DeserializeObject<List<FieldModels>>(models.datapost);

            var username = FormValue.Get(forms, "username");
            var password = Encryptor.MD5Hash(FormValue.Get(forms, "password"));  ;

            AccountHelpers account = new AccountHelpers(); 

            UserModels users =  account.logins(username, password);

 

            if (users != null)
            {
                Employee UserInfo;
                Nasabah NasabahInfo;
                HttpContext.Session.SetInt32(account.UserIdSessions, users.Id);
                HttpContext.Session.SetString(account.EmailSessions, users.Email);
                HttpContext.Session.SetString(account.PhoneSessions, users.Phone);
                HttpContext.Session.SetString(account.IsEmployeSessions, users.IsEmploye.ToString());

                if (users.IsEmploye)
                {
                    UserInfo = db.M_Employees.Where(s => s.UserId == users.Id).FirstOrDefault();
                    if (UserInfo.Name != null)
                    {
                        HttpContext.Session.SetString(account.NameSessions, UserInfo.Name);
                    }
                    
                   
                }
                else
                {
                   NasabahInfo = db.M_Nasabah.Where(s => s.UserId == users.Id).FirstOrDefault();
                    if (NasabahInfo.Name != null)
                    {
                        HttpContext.Session.SetString(account.NameSessions, NasabahInfo.Name);
                    }
                }

                return new APIResponse
                {
                    data = "../Home/Index",
                    message = "Succes Login",
                    status = true,
                };


            }else
            {
                return new APIResponse
                {
                    data = "../Account/Index",
                    message = "Failed Login",
                    status = false,
                };
            }

            
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Account"); 
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
