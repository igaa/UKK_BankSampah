using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKN_UKK.Models.Transaksi
{
    public class T_BuruanSae : Util.ModelHelpers
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public List<T_Panen> Panens { get; set; }
        public List<T_Penjualan> Penjualans { get; set; }
    }

    public class T_Panen  : Util.ModelHelpers
    {
        public int Id { get; set; }
        public DateTime tanggal { get; set; }
        public List<T_Items> items { get; set; }
       

    }

    public class T_Penjualan : Util.ModelHelpers 
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<T_Items> items { get; set; }
    }

    public class T_Items : Util.ModelHelpers 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string category { get; set; }
        public string Jenis { get; set; }
        public decimal Qty { get; set; }
        public decimal Harga { get;  set; }
        public string Unit { get; set; }
        public string Type { get; set;  }
        
    }
}
