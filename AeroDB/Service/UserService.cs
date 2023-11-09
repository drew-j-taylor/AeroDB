using AeroDB.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Windows.System;

namespace AeroDB.Service
{
    public class UserService
    {
        public UserService() { }
        AeroUser _user;
        string connectionString;
        public async Task<AeroUser> GetUser(string username, string password)
        {
            connectionString = $"server=localhost;user={username};database=aerodb;port=3306;password={password}";
            App.Conn = new MySqlConnection(connectionString);
            try
            {
                await App.Conn.OpenAsync();
                //App.Conn.Open();
                //var _user = await userService.GetUser(username, password);
                string sql = "SHOW GRANTS FOR current_user();";

                MySqlCommand cmd = new MySqlCommand(sql, App.Conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.HasRows)
                {
                    rdr.Close();
                    return null;
                }

                string role = "";
                while (rdr.Read())
                {
                    string[] subs = $"{rdr[0]}".Split('`');
                    role = subs[1];
                }
                //Console.WriteLine(role);
                rdr.Close();

                switch (role)
                {
                    case "Engineer":
                        _user = new Engineer(username, password);
                        break;

                    case "Materials":
                        _user = new Materials(username, password);
                        break;

                    case "ShopFloor":
                        _user = new ShopFloor(username, password);
                        break;
                }

                //if (role == "Engineer")
                //{
                //    _user = new Engineer(username, password);
                //}
                
            }
            catch
            {
                return null;
            }
            return _user;
        }
    }
}
