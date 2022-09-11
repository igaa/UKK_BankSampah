using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using KKN_UKK.Models; 
using KKN_UKK.Models.User;
using KKN_UKK.Models.Report;
using Microsoft.Data.SqlClient;

namespace KKN_UKK.Models.Entity
{
    public class DatabaseContextModels : DbContext
    {
        //Transaksi
        public DbSet<Transaksi.T_BankSampahModels> T_BankSampah { get; set; }
        public DbSet<Transaksi.T_Saldo> T_Saldo { get; set; }
        public DbSet<Transaksi.T_Mutasi> T_Mutasi { get; set; }
        public DbSet<Transaksi.T_TransaksiTimbangan> T_TransaksiTimbangan { get; set; }
        public DbSet<Transaksi.T_BuruanSae> T_BuruanSaes { get; set; }
        public DbSet<Transaksi.T_Panen> T_Panen { get; set; }
        public DbSet<Transaksi.T_Penjualan> T_Penjualan { get; set; }
        public DbSet<Transaksi.T_Items> T_Items { get; set; }
        public DbSet<Transaksi.T_ODFModels> T_Odf { get; set; }

        //End Transaksi
        public DbSet<Master.MasterSampah> M_MasterSampah { get; set; }
        public DbSet<Master.MasterLocations> M_MasterLocations { get; set; }
        public DbSet<Master.Master> M_Masters { get; set; }
        public DbSet<User.UserModels> M_Users { get; set; }
        public DbSet<User.Employee> M_Employees { get; set; }
        public DbSet<User.Nasabah> M_Nasabah { get; set; }
        public DbSet<User.Roles> M_Role { get; set; }
        public DbSet<LaporanHarianBarang> barang { get; set;  }

        //public DbSet<User> Users {get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Ukk_BankSampah;Trusted_Connection=True;");
        }
        //public DbSet<User> Users {get; set; }
        public DbSet<KKN_UKK.Models.User.Profile> Profile { get; set; }

        public IEnumerable<LaporanHarianBarang> LaporanHarianQuery(DateTime? startDate, DateTime? endDate)
        {
            List<LaporanHarianBarang> barang = this.barang.FromSqlRaw("EXEC [dbo].[ReportItems] @StartDate, @EndDate",
            new SqlParameter("@StartDate", startDate),
            new SqlParameter("@EndDate", endDate)).ToList();

            return barang; 
        }
    }

}
