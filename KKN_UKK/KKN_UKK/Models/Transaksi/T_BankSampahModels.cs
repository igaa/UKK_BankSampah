using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKN_UKK.Models.User;
using KKN_UKK.Models.Util;
using KKN_UKK.Models.Master;
using System.ComponentModel.DataAnnotations;

namespace KKN_UKK.Models.Transaksi
{
    public class T_BankSampahModels : ModelHelpers 
    {
        public int Id { get; set; }
        public T_Saldo saldo {get; set; }
        public T_Mutasi mutasi { get; set;  }
        public List<T_TransaksiTimbangan> transaksi { get; set;  }
    }

    public class T_Saldo
    {
        public int Id { get; set; }
        public int NasabahId { get; set; }
        public decimal Jumlah { get; set; }

    }

    public class T_Mutasi
    {
        public int Id { get; set; }
        public int NasabahId { get; set; }
        public string NamaNasabah { get; set;}

        [Required]
        public decimal Jumlah { get; set; }
        public DateTime Date { get; set; }
        public string Decription { get; set; }
    }

    public class NasabahInfo
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public decimal Saldo { get; set; }
    }

    public class T_TransaksiTimbangan : ModelHelpers
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int NasabahId { get; set; }
        public string NamaNasabah { get; set; }
        public string AccountNumber { get; set; }
        public string Items { get; set; }
        public string Category { get; set;}
        public decimal HargaSatuan { get; set; }
        public decimal Qty { get; set; }
        public decimal TotalHarga { get; set; }
        public string Unit { get; set;  }
        public string Description { get; set; }

    }

    public class TransaksiTimbangan : ModelHelpers
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int NasabahId { get; set; }
        public string NamaNasabah { get; set; }
        public string AccountNumber { get; set; }
        public string Items { get; set; }
        public string itemName { get; set;  }
        public string Category { get; set; }
        public decimal HargaSatuan { get; set; }
        public decimal Qty { get; set; }
        public decimal TotalHarga { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }

    }

}
