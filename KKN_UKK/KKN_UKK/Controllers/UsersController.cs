using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKN_UKK.Models.User;
using KKN_UKK.Models.Entity;
using KKN_UKK.Helpers;
using Microsoft.AspNetCore.Http;

namespace KKN_UKK.Controllers
{
    public class UsersController : Controller
    {
        private DatabaseContextModels db = new DatabaseContextModels();

        private AccountHelpers accountInfo = new AccountHelpers();
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                var UserList = db.M_Users.Where(s => s.IsActive == true).ToList();
                return View(UserList);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
            
        }

        public IActionResult Profile(string id)
        {

            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                ViewBag.Id = id;
                int Id = Convert.ToInt32(id);
                var users = db.M_Users.Where(s => s.Id == Id).FirstOrDefault();

                Profile profile = new Profile();
                profile.Id = users.Id;
                profile.Email = users.Email;
                profile.Phone = users.Phone;

                if (users.IsEmploye)
                {
                    Employee emp = db.M_Employees.Where(s => s.UserId == Id).FirstOrDefault();
                    profile.NIK = emp.NIK;
                    profile.Firstname = emp.Firstname;
                    profile.MidleName = emp.MidleName;
                    profile.LastName = emp.LastName;
                    profile.Name = emp.Name;
                    profile.Birtdate = emp.Birtdate;
                    profile.JenisKelamin = emp.JK;
                    profile.Alamat = emp.Alamat;


                }
                else
                {
                    Nasabah nas = db.M_Nasabah.Where(s => s.UserId == Id).FirstOrDefault();

                    profile.NIK = nas.NIK;
                    profile.Firstname = nas.Firstname;
                    profile.MidleName = nas.MidleName;
                    profile.LastName = nas.LastName;
                    profile.Name = nas.Name;
                    profile.Birtdate = nas.Birtdate;
                    profile.JenisKelamin = nas.JK;
                    profile.Alamat = nas.Alamat;
                }


                return View(profile);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

            

        }

        public IActionResult UpdateProfil(Profile data)
        {


            string id = string.Empty;

            var users = db.M_Users.Where(s => s.Id == data.Id).FirstOrDefault();

            users.Email = data.Email;
            users.Phone = data.Phone;

            db.SaveChanges(); 

            if (users.IsEmploye)
            {
                Employee emp = db.M_Employees.Where(s => s.UserId == users.Id).FirstOrDefault();
                emp.NIK = data.NIK;
                emp.Firstname = data.Firstname;
                emp.MidleName = data.MidleName;
                emp.LastName = data.LastName;
                emp.Name = string.Format("{0} {1} {2}", data.Firstname, data.MidleName, data.LastName);
                emp.Birtdate = data.Birtdate;
                emp.JK = data.JenisKelamin;
                emp.Alamat = data.Alamat;
                db.SaveChanges();

            }
            else
            {
                Nasabah nas = db.M_Nasabah.Where(s => s.UserId == users.Id).FirstOrDefault();

                nas.NIK = data.NIK;
                nas.Firstname = data.Firstname;
                nas.MidleName = data.MidleName;
                nas.LastName = data.LastName;
                nas.Name = string.Format("{0} {1} {2}", data.Firstname, data.MidleName, data.LastName);
                nas.Birtdate = data.Birtdate;
                nas.JK = data.JenisKelamin;
                nas.Alamat = data.Alamat;

                db.SaveChanges(); 
            }

            id = users.Id.ToString(); 

            return RedirectToAction("Profil", "Users", new { id = id }); 
        }

        public IActionResult EditProfile(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                var users = db.M_Users.Where(s => s.Id == Id).FirstOrDefault();

                Profile profile = new Profile();
                profile.Id = users.Id;
                profile.Email = users.Email;
                profile.Phone = users.Phone;

                if (users.IsEmploye)
                {
                    Employee emp = db.M_Employees.Where(s => s.UserId == Id).FirstOrDefault();
                    profile.NIK = emp.NIK;
                    profile.Firstname = emp.Firstname;
                    profile.MidleName = emp.MidleName;
                    profile.LastName = emp.LastName;
                    profile.Name = emp.Name;
                    profile.Birtdate = emp.Birtdate;
                    profile.JenisKelamin = emp.JK;
                    profile.Alamat = emp.Alamat;


                }
                else
                {
                    Nasabah nas = db.M_Nasabah.Where(s => s.UserId == Id).FirstOrDefault();

                    profile.NIK = nas.NIK;
                    profile.Firstname = nas.Firstname;
                    profile.MidleName = nas.MidleName;
                    profile.LastName = nas.LastName;
                    profile.Name = nas.Name;
                    profile.Birtdate = nas.Birtdate;
                    profile.JenisKelamin = nas.JK;
                    profile.Alamat = nas.Alamat;
                }

                ViewBag.Id = profile.Id.ToString();

                return View(profile);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
           
        }

        public IActionResult Create()
        {

            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
         
        }

        public IActionResult Edit(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                var data = db.M_Users.Where(s => s.Id == Id).FirstOrDefault();
                ViewBag.IsEmploye = data.IsEmploye;
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }

        public IActionResult Delete(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                var data = db.M_Users.Where(s => s.Id == Id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
          
        }
        public IActionResult Details(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                var data = db.M_Users.Where(s => s.Id == Id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
          
        }
        public IActionResult Insert(UserModels data)
        {
            data.IsEmploye = true; 
            data.Password = Encryptor.MD5Hash(data.Password);
            data.IsActive = true;
            data.CreateBy = HttpContext.Session.GetInt32(accountInfo.UserIdSessions).ToString();
            data.CreateAt = DateTime.Now; 
            db.M_Users.Add(data);
            db.SaveChanges(); 

            if (data.IsEmploye)
            {
                Employee employe = new Employee();
                employe.Name = data.Username;
                employe.UserId = data.Id;

                db.M_Employees.Add(employe);
                db.SaveChanges(); 

            }
         
            return RedirectToAction("Index", "Users");
        }

        private string GetOldpassword(int Id)
        {
            return db.M_Users.Where(s => s.Id == Id).FirstOrDefault().Password; 
        }
        public IActionResult Update(UserModels data)
        {
            var oldpass = GetOldpassword(data.Id); 

            if (!string.IsNullOrEmpty(data.Password))
            {
                var newpass = Encryptor.MD5Hash(data.Password); 
                if (oldpass != newpass)
                {
                    data.Password = newpass;
                }else
                {
                    data.Password = oldpass; 
                }
            }else
            {
                data.Password = oldpass;
            }
            
            

            UserModels user = db.M_Users.Where(s => s.Id == data.Id).FirstOrDefault();
            user.Username = data.Username;
            user.Password = data.Password;
            user.Email = data.Email;
            user.Phone = data.Phone;
            if (user.IsEmploye)
            {
                user.Role = data.Role;
            }
            
            user.UpdateBy = HttpContext.Session.GetInt32(accountInfo.UserIdSessions).ToString();
            user.UpdateAt = DateTime.Now;

            //db.M_Users.Update(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Users"); 
        }
        public IActionResult Remove(int Id)
        {
            var dt = db.M_Users.Where(s => s.Id == Id).FirstOrDefault();
            dt.IsActive = false;
            db.M_Users.Update(dt); 

            return RedirectToAction("Index", "Users");
        }
    }
}
