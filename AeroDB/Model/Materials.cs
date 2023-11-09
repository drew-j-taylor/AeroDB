using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroDB.Model
{
    public class Materials : AeroUser
    {
        public Materials(string username, string password)
        {
            UserName = username;
            Password = password;
            PartAlter = false;
            AssyAlter = false;
            WoAlter = true;
            InventoryAlter = true;
        }
    }
}
