using KKN_UKK.Models.Entity;
using KKN_UKK.Models.Transaksi;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KKN_UKK.Controllers
{
    public class ReportController : Controller
    {
        private DatabaseContextModels db = new DatabaseContextModels();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Transaksi()
        {
            List<T_TransaksiTimbangan> list = new List<T_TransaksiTimbangan>(); 
            return View(list); 
        }


      

    }

    
}
