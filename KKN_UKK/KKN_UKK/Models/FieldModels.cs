using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKN_UKK.Models
{
    public class FieldModels
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class FormValue
    {
        public static string Get(List<FieldModels> list, string name)
        {
            string value = string.Empty;

            foreach (var item in list)
            {
                if (item.name == name)
                {
                    value = item.value;
                    break; 
                }

            }

            return value; 
        }
    }
}
