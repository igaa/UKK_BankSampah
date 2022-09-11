using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKN_UKK.Models.Transaksi;
using KKN_UKK.Models.User; 
using KKN_UKK.Models.Entity;
using KKN_UKK.Helpers;
using KKN_UKK.Models.Master;
using Microsoft.AspNetCore.Http;

namespace KKN_UKK.Controllers
{
    public class BanksampahController : Controller
    {
        private DatabaseContextModels db = new DatabaseContextModels();

        private AccountHelpers accountInfo = new AccountHelpers();

        //private Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction trans =.db.Database.BeginTransaction(); 
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                var tabungan = db.T_TransaksiTimbangan.ToList();
                return View(tabungan);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
          
        }

        public IActionResult PenarikanDana()
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                var Mutasi = db.T_Mutasi.ToList();
                return View(Mutasi);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
           
        }

        public APIResponse SetNasabahInfo(int Id)
        {
            var data = db.M_Nasabah.Where(s => s.id == Id).FirstOrDefault();
            decimal totalSaldo = db.T_TransaksiTimbangan.Where(s => s.NasabahId == Id).Sum(s => s.TotalHarga);
            decimal pencairan = db.T_Mutasi.Where(s => s.NasabahId == Id).Sum(s => s.Jumlah);
            var saldo = totalSaldo - pencairan; 
            NasabahInfo dt = new NasabahInfo { 
                Id = Id, 
                Nama = data.Name, 
                Saldo = saldo,
            };

            return new APIResponse()
            {
                data = dt,
                message = "Succes Get Data", 
                status = true,

            }; 
        }
        public APIResponse checkSaldo(int id, decimal penarikan)
        {
            APIResponse result = new APIResponse();
            decimal totalSaldo = db.T_TransaksiTimbangan.Where(s => s.NasabahId == id).Sum(s => s.TotalHarga);
            decimal pencairan = db.T_Mutasi.Where(s => s.NasabahId == id).Sum(s => s.Jumlah); 
            decimal saldo = totalSaldo - pencairan; 
            if (saldo < penarikan)
            {
                result.data = false; 
            }else
            {
                result.data = true; 
            }

            result.message = "Success Get Data"; 
            result.status = true; 

            return result; 
           
        }
        public IActionResult CreatePencairan()
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                var nasabah = db.M_Nasabah.ToList();
                ViewBag.Nasabah = nasabah;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
            
        }
        public IActionResult InsertPencairan(T_Mutasi data)
        {
            data.Date = DateTime.Now;

            db.T_Mutasi.Add(data);
            db.SaveChanges();

            return RedirectToAction("PenarikanDana", "Banksampah"); 
        }

        public IActionResult UpdatePencairan(T_Mutasi data)
        {
            db.T_Mutasi.Update(data); 
            db.SaveChanges(); 
            return RedirectToAction("PenarikanDana", "Banksampah");
        }

        public IActionResult RemovePencairan(int Id)
        {
            var dt = db.T_Mutasi.Where(s => s.Id == Id).FirstOrDefault();
            db.T_Mutasi.Remove(dt);
            db.SaveChanges(); 
            return RedirectToAction("PenarikanDana", "Banksampah");
        }

        public IActionResult EditPencarian(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                var nasabah = db.M_Nasabah.ToList();
                ViewBag.Nasabah = nasabah;
                var data = db.T_Mutasi.Where(s => s.Id == Id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
           
        }

        public IActionResult DetailPencarian(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                var data = db.T_Mutasi.Where(s => s.Id == Id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

           
        }
        public IActionResult DeletePencarian(int Id)
        {

            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                var data = db.T_Mutasi.Where(s => s.Id == Id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

         
        }
        public IActionResult GetDetailTimbanganByUserId(int id)
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

        public IActionResult ActionNasabah(Nasabah data)
        {
            data.AccountNumber = DateTime.Now.ToString("ddMMyy") + string.Format("{0:D5}", (db.M_Nasabah.Count() + 1));
            UserModels user = new UserModels();
            user.Username = data.AccountNumber; 
            user.Password = null;  
            user.IsEmploye = false; 
            user.CreateBy = HttpContext.Session.GetInt32(accountInfo.UserIdSessions).ToString();
            user.IsActive = true;
            user.Role = "USER"; 
            db.M_Users.Add(user);
            db.SaveChanges(); 

            data.Name = string.Format("{0} {1} {2}", data.Firstname, data.MidleName, data.LastName);
            Nasabah nasabahs = new Nasabah();
            nasabahs = data;
            nasabahs.UserId = user.Id; 
            nasabahs.CreateAt = DateTime.Now;
            nasabahs.CreateBy = HttpContext.Session.GetInt32(accountInfo.UserIdSessions).ToString();

            db.M_Nasabah.Add(nasabahs);
            db.SaveChanges(); 

            

            return RedirectToAction("ListNasabah", "BankSampah"); 
        }

        public IActionResult ListNasabah()
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                List<Nasabah> nasabahs = db.M_Nasabah.ToList();
                return View(nasabahs);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        
        }

        public IActionResult CreateNasabah()
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

        public IActionResult EditNasabah(int id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                Nasabah data = db.M_Nasabah.Where(s => s.id == id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
       
        }

        public IActionResult NasabahEdit(Nasabah data)
        {
            Nasabah edit = data; 
            edit.Name = string.Format("{0} {1} {2}", data.Firstname, data.MidleName, data.LastName);
            edit.UpdateAt = DateTime.Now;
            edit.UpdateBy = HttpContext.Session.GetInt32(accountInfo.UserIdSessions).ToString();
            db.M_Nasabah.Update(edit); 
            db.SaveChanges(); 
            return RedirectToAction("ListNasabah", "BankSampah");
        }

        public IActionResult DetailNasabah(int id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                Nasabah data = db.M_Nasabah.Where(s => s.id == id).FirstOrDefault();
                decimal totalSaldo = db.T_TransaksiTimbangan.Where(s => s.NasabahId == id).Sum(s => s.TotalHarga);
                decimal pencairan = db.T_Mutasi.Where(s => s.NasabahId == id).Sum(s => s.Jumlah);
                var saldo = totalSaldo - pencairan;
                ViewBag.Saldo = saldo;
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
         
        }

        public IActionResult DeleteNasabah(int id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                Nasabah data = db.M_Nasabah.Where(s => s.id == id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
            
        }

        public IActionResult NasabahDelete(int id)
        {


            Nasabah data = db.M_Nasabah.Where(s => s.id == id).FirstOrDefault();
            db.M_Nasabah.Remove(data);
            db.SaveChanges(); 
            return RedirectToAction("ListNasabah", "BankSampah");

        }

        public IActionResult InsertTimbangan(T_TransaksiTimbangan model)
        {
            model.ItemsName = db.M_MasterSampah.Where(s => s.Id.ToString() == model.Items).FirstOrDefault().Nama; 
            model.CreateAt = DateTime.Now;
            model.CreateBy = HttpContext.Session.GetInt32(accountInfo.UserIdSessions).ToString();
            db.T_TransaksiTimbangan.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index", "BankSampah" ); 
            
        }
        public IActionResult TimbanganCreate()
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                ViewBag.Location = db.M_MasterLocations.ToList();
                ViewBag.MasterSampah = db.M_MasterSampah.ToList();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

         
        }

        public IActionResult EditTransaksi(T_TransaksiTimbangan data)
        {
            T_TransaksiTimbangan edit =data;
            edit.ItemsName = db.M_MasterSampah.Where(s => s.Id.ToString() == data.Items).FirstOrDefault().Nama; 
            edit.UpdateAt = DateTime.Now;
            edit.UpdateBy = HttpContext.Session.GetInt32(accountInfo.UserIdSessions).ToString();
            db.T_TransaksiTimbangan.Update(edit); 
            db.SaveChanges(); 

            return RedirectToAction("Index", "BankSampah");
        }

        public IActionResult TimbanganEdit(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                T_TransaksiTimbangan data = db.T_TransaksiTimbangan.Where(s => s.Id == Id).FirstOrDefault();
                ViewBag.Location = db.M_MasterLocations.ToList();
                ViewBag.MasterSampah = db.M_MasterSampah.ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
           
        }

        public IActionResult TimanganDetails(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                T_TransaksiTimbangan data = db.T_TransaksiTimbangan.Where(s => s.Id == Id).FirstOrDefault();

                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
           
        }
        public IActionResult DeleteTransaksi(int Id)
        {

            T_TransaksiTimbangan data = db.T_TransaksiTimbangan.Where(s => s.Id == Id).FirstOrDefault(); 
            db.T_TransaksiTimbangan.Remove(data);
            db.SaveChanges(); 

            return RedirectToAction("Index", "BankSampah"); 
        }
        public IActionResult TimbanganDelete(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                T_TransaksiTimbangan data = db.T_TransaksiTimbangan.Where(s => s.Id == Id).FirstOrDefault();

                //db.t_TransaksiTimbangans.Remove(data);
                //db.SaveChanges();

                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        

        }
        public APIResponse NasabahByParams(string param)
        {
            var Nasabah = db.M_Nasabah.Where(s => s.Name.ToLower().Contains(param.ToLower().Trim()) || s.AccountNumber.Contains(param.Trim())).ToList();

            //ActionResult<Nasabah> T_Nasabah = new ActionResult<Nasabah>(); 
            return new APIResponse {
                data = Nasabah,
                message = "Succes Get Data", 
                status = true,
            };
        }

        public APIResponse GetMasterItems(int Id)
        {
            var MasterData = db.M_MasterSampah.Where(s => s.Id == Id).ToList(); 
            return new APIResponse
            {
                data = MasterData,
                message = "Succes Get Data",
                status = true,
            };
        }

        public IActionResult MasterSampah()
        {

            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                List<MasterSampah> master = db.M_MasterSampah.ToList();
                //ViewBag.MasterSampah = db.m_Masters.Where(s => s.Flag == "Category").ToList(); 

                return View(master);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
          
        }

        public IActionResult InsertSampah(MasterSampah data)
        {
            MasterSampah dt = data; 
            db.M_MasterSampah.Add(dt);
            db.SaveChanges(); 

            return RedirectToAction("MasterSampah", "BankSampah");
        }
        public IActionResult UpdateSampah(MasterSampah data)
        {
            db.M_MasterSampah.Update(data); 
            db.SaveChanges(); 

            return RedirectToAction("MasterSampah", "BankSampah");
        }

        public IActionResult RemoveSampah(int Id)
        {
            MasterSampah data = db.M_MasterSampah.Where(s => s.Id == Id).FirstOrDefault();
            db.M_MasterSampah.Remove(data);
            db.SaveChanges(); 
            return RedirectToAction("MasterSampah", "BankSampah");
        }

        public IActionResult CreateSampah()
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                MasterSampah data = new MasterSampah();
                ViewBag.MasterSampah = db.M_Masters.Where(s => s.Flag == "Category").ToList();

                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
            
        }

        public IActionResult EditSampahById(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                MasterSampah data = db.M_MasterSampah.Where(s => s.Id == Id).FirstOrDefault();
                ViewBag.MasterSampah = db.M_Masters.Where(s => s.Flag == "Category").ToList();

                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
           
        }

        public IActionResult DeleteSampahById(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                MasterSampah data = db.M_MasterSampah.Where(s => s.Id == Id).FirstOrDefault();

                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
            
        }

        public IActionResult GetSampahById(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                MasterSampah data = db.M_MasterSampah.Where(s => s.Id == Id).FirstOrDefault();

                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
           
        }

        public IActionResult MasterLocation()
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                var locations = db.M_MasterLocations.ToList();
                return View(locations);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
         
        }

        public IActionResult UpdateLocation(MasterLocations data)
        {
            db.M_MasterLocations.Update(data); 
            db.SaveChanges(); 

            return RedirectToAction("MasterLocation", "BankSampah"); 
        }
        public IActionResult InsertLocation(MasterLocations data)
        {
            MasterLocations dt = data;
            db.M_MasterLocations.Add(dt);
            db.SaveChanges(); 

            return RedirectToAction("MasterLocation", "BankSampah");
        }
        public IActionResult RemoveLocation(int Id)
        {
            MasterLocations data = db.M_MasterLocations.Where(s => s.Id == Id).FirstOrDefault();
            db.M_MasterLocations.Remove(data);
            db.SaveChanges(); 
            return RedirectToAction("MasterLocation", "BankSampah");
        }

        public IActionResult EditLocation(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                MasterLocations data = db.M_MasterLocations.Where(s => s.Id == Id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
            
        }

        public IActionResult CreateLocation()
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                MasterLocations data = new MasterLocations();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
            
        }

        public IActionResult DetailLocation(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                MasterLocations data = db.M_MasterLocations.Where(s => s.Id == Id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

         
        }

        public IActionResult DeleteLocation(int Id)
        {
            if (HttpContext.Session.GetInt32(accountInfo.UserIdSessions) != null)
            {
                MasterLocations data = db.M_MasterLocations.Where(s => s.Id == Id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
           
        }
    }
}
