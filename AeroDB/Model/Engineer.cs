using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroDB.Model
{
    public class Engineer : AeroUser
    {
        public Engineer(string username, string password)
        {
            UserName = username;
            Password = password;
            PartAlter = true;
            BomAlter = true;
            WoAlter = true;
            InventoryAlter = false;
        }

    }
}
