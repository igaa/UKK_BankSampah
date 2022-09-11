using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKN_UKK.Models
{
    public class LoginModels
    {
        public string datapost {get; set; }
    }

    public class SearchModels
    {
        public string search { get; set;  }
    }

    public class searchParams
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class PostModels
    {
        
        public DateTime StartDate { get; set;  }
        public DateTime EndDate { get; set;  }
        public string param { get; set; }
        public string datapost { get; set; }
        public string searchBy { get; set;  }
    }

}
