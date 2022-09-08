using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKN_UKK.Models.Master;
using KKN_UKK.Models.Entity;
using Microsoft.AspNetCore.Http;
using KKN_UKK.Helpers;

namespace KKN_UKK.Controllers
{
    public class MasterController : Controller
    {
        private DatabaseContextModels db = new DatabaseContextModels();
        private AccountHelpers accountInfo = new AccountHelpers();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {

            return View(); 
        }

        public IActionResult Category()
        {

            return View(); 

        } 
        public IActionResult Product()
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                List<Master> master = db.M_Masters.Where(s => s.Flag == "Category").ToList();
                return View(master);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
            
        }

        public IActionResult InsertProduct(Master master)
        {
            master.Flag = "Category"; 
            db.M_Masters.Add(master);
            db.SaveChanges(); 
            return RedirectToAction("Product", "Master"); 
        }

        public IActionResult UpdateProduct(Master master)
        {
            Master data = db.M_Masters.Where(s => s.Id == master.Id).FirstOrDefault();
            data.Nama = master.Nama;
            data.Value = master.Value;
            data.Description = master.Description;
            db.SaveChanges(); 

            return RedirectToAction("Product", "Master");
        }

        public IActionResult RemoveProduct(int Id)
        {
            Master data = db.M_Masters.Where(s => s.Id == Id).FirstOrDefault();
            db.M_Masters.Remove(data);
            db.SaveChanges(); 
            return RedirectToAction("Product", "Master");
        }
        public IActionResult CreateProduct()
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                Master data = new Master();

                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
           
        }

        public IActionResult EditProduct(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                Master data = db.M_Masters.Where(s => s.Id == Id).FirstOrDefault();


                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
         
        }

        public IActionResult DeleteProduct(int Id)
        {

            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                Master data = db.M_Masters.Where(s => s.Id == Id).FirstOrDefault();


                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
           
        }

        public IActionResult DetailProduct(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                Master data = db.M_Masters.Where(s => s.Id == Id).FirstOrDefault();

                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
          
        }

        public IActionResult Employee()
        {
            return View(); 
        }

        public IActionResult Penduduk()
        {
            return View(); 
        }
        public IActionResult Roles()
        {
            return View();
        }
    }
}
