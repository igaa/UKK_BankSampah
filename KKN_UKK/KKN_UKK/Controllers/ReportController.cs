using ClosedXML.Excel;
using KKN_UKK.Helpers;
using KKN_UKK.Models;
using KKN_UKK.Models.Entity;
using KKN_UKK.Models.Transaksi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO; 

namespace KKN_UKK.Controllers
{
    public class ReportController : Controller
    {
        private IWebHostEnvironment _webHostEnvironment; 

        public ReportController(IWebHostEnvironment _env)
        {
            _webHostEnvironment = _env; 
        }
        private DatabaseContextModels db = new DatabaseContextModels();
        private AccountHelpers accountInfo = new AccountHelpers();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Transaksi()
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                string page = HttpContext.Request.Query["startDate"].ToString();
                List<T_TransaksiTimbangan> list = new List<T_TransaksiTimbangan>();

                return View(list);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
            
        }

        public IActionResult Items()
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




        

        [HttpPost]
        public APIResponse Preview([FromForm] SearchModels form)
        {
            try
            {
                List<FieldModels> forms = JsonConvert.DeserializeObject<List<FieldModels>>(form.search);

                var StartDate =FormValue.Get(forms, "startDate");
                var EndDate =FormValue.Get(forms, "endDate");
                var NasabahId = FormValue.Get(forms, "nasabahId");

                var query = db.T_TransaksiTimbangan.Select(s => new {
                    s.AccountNumber,
                    s.Category,
                    s.CreateAt,
                    s.CreateBy,
                    s.Description,
                    s.HargaSatuan,
                    s.Id,
                    s.Items,
                    itemName = db.M_MasterSampah.Where(x => x.Id.ToString() == s.Items).FirstOrDefault().Nama,
                    s.Location,
                    s.NamaNasabah,
                    s.NasabahId,
                    s.Qty,
                    s.Unit,
                    s.TotalHarga,
                    s.UpdateAt,
                    s.UpdateBy,
                }).ToList() ;


                if (!string.IsNullOrEmpty(StartDate) && !string.IsNullOrEmpty(EndDate))
                {
                    query = query.Where(s => s.CreateAt >= Convert.ToDateTime(StartDate) && s.CreateAt <= Convert.ToDateTime(EndDate)).ToList(); 
                }

                if (!string.IsNullOrEmpty(NasabahId))
                {
                    int IdNasabah = Convert.ToInt32(NasabahId);
                    query = query.Where(s => s.NasabahId == IdNasabah).ToList(); 
                }


                return new APIResponse
                {
                    data = query,
                    message = "Success",
                    status = true, 
                };
                
            }
            catch (Exception ex)
            {
                return new APIResponse { 
                    message = ex.Message, 
                    status = false,
                };
            }
           
        }

        public APIResponse ExportTransaksiXls([FromForm] PostModels data)
        {
            try
            {
                List<TransaksiTimbangan> models = JsonConvert.DeserializeObject<List<TransaksiTimbangan>>(data.datapost);
                string wwwPath = this._webHostEnvironment.WebRootPath; 

                var url = "";
                var templatePath = wwwPath + "\\Template\\TEMPLATE1.xlsx"; 
                using (XLWorkbook workbook = new XLWorkbook(templatePath))
                {
                    var sheet = workbook.Worksheet(1);
                    var no = 0;  
                    foreach (var item in models)
                    {
                        no +=1;
                        int row = no + 1;  
                        sheet.Cell("A"+row).Value = no;
                        sheet.Cell("B"+row).Value = item.CreateAt;
                        sheet.Cell("C"+row).Value = item.Location;
                        sheet.Cell("D"+row).Value = item.NamaNasabah;
                        sheet.Cell("E"+row).Value = item.itemName;
                        sheet.Cell("F"+row).Value = item.Category;
                        sheet.Cell("G"+row).Value = item.HargaSatuan;
                        sheet.Cell("H"+row).Value = item.Qty;
                        sheet.Cell("I"+row).Value = item.Unit;
                        sheet.Cell("J"+row).Value = item.TotalHarga;
                    }


                    //IHostingEnvironment env; 
                    var filename = "Laporan-Transaksi-" + DateTime.Now.ToString("dd-MM-yyyy")+".xlsx"; 

                    var OutPath = wwwPath + "\\Export\\"+filename;

                    if (System.IO.File.Exists(OutPath))
                    {
                        System.IO.File.Delete(OutPath); 
                    }

                    workbook.SaveAs(OutPath);
                    url = "../Export/" + filename; 
                }

                return new APIResponse
                {
                    data = url,
                    message = "Succes Export",
                    status = true, 

                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    message = string.Format("Failed Export Data ! Details : {0}", ex.Message), 
                    status = false, 
                };
            }

        }
    }

    
}
