using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKN_UKK.Models.Report
{
    public class ReportHarianModel
    {
        public int No { get; set;  }
        public DateTime tanggal { get; set;  }
        public string Nama  { get; set; }
        public string Items { get; set; }
        public string Qty { get; set; }
        public string Unit { get; set;  }
    }
}
