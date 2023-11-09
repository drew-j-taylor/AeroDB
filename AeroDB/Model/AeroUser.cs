using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroDB.Model
{
    public abstract class AeroUser
    {
        //public AeroUser(string username, string password)
        //{
        //    UserName = username;
        //    Password = password;
        //}
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool PartAlter { get; set; }
        public bool BomAlter { get; set; }
        public bool WoAlter { get; set; }
        public bool InventoryAlter { get; set; }
    }
}
