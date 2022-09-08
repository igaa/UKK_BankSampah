using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKN_UKK.Controllers
{
    public class OdfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
