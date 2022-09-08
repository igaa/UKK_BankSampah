using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKN_UKK.Models.Transaksi;
using KKN_UKK.Models.Entity;
using KKN_UKK.Helpers;
using Microsoft.AspNetCore.Http;

namespace KKN_UKK.Controllers
{
    public class BuruansaeController : Controller
    {
        private DatabaseContextModels db = new DatabaseContextModels();

        private AccountHelpers accountInfo = new AccountHelpers();
        public IActionResult Index()
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

        public IActionResult Penjualan()
        {
            List<T_Penjualan> penjualans = new List<T_Penjualan>(); 
            return View(penjualans); 
        }

        public IActionResult Panen()
        {
            List<T_Panen> panens = new List<T_Panen>(); 
            return View(panens); 
        }

    }
}
