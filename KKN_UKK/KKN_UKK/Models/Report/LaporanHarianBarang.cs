using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKN_UKK.Models.Report
{
    public class LaporanHarianBarang
    {
        public int Id { get; set;  }
        public string ItemsName { get; set; }
        public decimal HargaSatuan { get; set;  }
        public decimal Qty { get; set; }
        public string Unit {get; set; }
        public decimal TotalHarga { get; set; }
    }
}
