using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKN_UKK.Models.Util; 

namespace KKN_UKK.Models.Master
{
    public class Master: ModelHelpers
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Value { get; set; }
        public string Flag { get; set; }
        public string Description { get; set;  }

    }

    public class Menus : ModelHelpers
    {
        public int Id { get; set; }
        public string Nama { get; set;  }
        public string Url { get; set;  }
        public string Parent { get; set; }
        public string Icons { get; set; }
    }

    public class MasterSampah {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Category { get; set; }
        public decimal Harga { get; set;  }
        public string Unit { get; set; }
    }

    public class MasterLocations
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Description { get; set;  }

    }
}
