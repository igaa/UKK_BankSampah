using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using KKN_UKK.Models.Util; 

namespace KKN_UKK.Models.User
{
    public class UserModels : ModelHelpers 
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public bool IsEmploye { get; set;  }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email  { get; set; }
        public  string Phone { get; set; }
        public bool IsActive { get; set;  }

    }

    public class Profile
    {
        public int Id { get; set; }
        public string NIK { get; set; }
        public string Firstname { get; set; }
        public string MidleName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public DateTime Birtdate { get; set; }
        public string JenisKelamin { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Alamat { get; set; }
    }

    public class Employee : ModelHelpers 
    {
        public int Id { get; set; }
        public string NIK { get; set; }
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string MidleName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string JK { get; set; }
        public string Image { get; set; }
        [MaxLength(1024)]
        public DateTime Birtdate { get; set; }
        public string Rt { get; set; }
        public string Rw { get; set; }
        public string Alamat { get; set; }
    }

    public class Nasabah : ModelHelpers
    {
        public int id { get; set; }
        public string NIK { get; set; }
        public string AccountNumber { get; set; }
        public int UserId { get; set;  }
        public string Firstname { get; set; }
        public string MidleName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string JK { get; set; }
        public string Image { get; set; }
        public DateTime Birtdate { get; set; }
        public string Rt { get; set;  }
        public string Rw { get; set;  }
        public string Alamat { get; set; }
    }

    public class Nasabahs
    {
        public int id { get; set; }
        public string NIK { get; set;  }
        public string AccountNumber { get; set; }
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string MidleName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string JK { get; set; }
        public string Image { get; set; }
        public string Birtdate { get; set; }
        public string Rt { get; set; }
        public string Rw { get; set; }
        public string Alamat { get; set; }
    }

    public class Roles : ModelHelpers
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Value { get; set; }
        public bool IsActive{ get; set; }
        [MaxLength(1024)]
        public string Decription  { get; set; }
    }
}
