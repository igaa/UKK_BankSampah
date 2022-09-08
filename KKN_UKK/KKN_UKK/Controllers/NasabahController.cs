using KKN_UKK.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKN_UKK.Models.Transaksi;
using KKN_UKK.Models.Entity;

namespace KKN_UKK.Controllers
{
    public class NasabahController : Controller
    {
        DatabaseContextModels db = new DatabaseContextModels();
        private AccountHelpers accountInfo = new AccountHelpers();

        // GET: NasabahController
        public ActionResult Index()
        {

            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                AccountHelpers account = new AccountHelpers();

                var Id = Convert.ToInt32(HttpContext.Session.GetInt32(account.UserIdSessions));
                var nasabahId = db.M_Nasabah.Where(s => s.UserId == Id).FirstOrDefault().id;
                var transaksi = db.T_TransaksiTimbangan.Where(s => s.NasabahId == nasabahId);


                decimal totalSaldo = db.T_TransaksiTimbangan.Where(s => s.NasabahId == nasabahId).Sum(s => s.TotalHarga);
                decimal pencairan = db.T_Mutasi.Where(s => s.NasabahId == nasabahId).Sum(s => s.Jumlah);
                var saldo = totalSaldo - pencairan;

                ViewBag.Saldo = saldo;
                ViewBag.Id = Id;
                return View(transaksi);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
            
        }

    
    }
}
