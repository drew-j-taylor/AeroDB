using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AeroDB.Service;
using AeroDB.View;
using MySql.Data.MySqlClient;

namespace AeroDB.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string username;

        [ObservableProperty] 
        public string password;

        [ObservableProperty]
        public string status = "";

        //string connectionString;// = $"server=localhost;user={username};database=aerodb;port=3306;password={password}";


        UserService userService;

        //IConnectivity connectivity;

        public LoginViewModel(UserService userService) 
        {
            Title = "AeroDB";
            this.userService = userService;
            //this.connectivity = connectivity;
        }

        [RelayCommand]
        async Task LoginGetUser() 
        {
            //connectionString = $"server=localhost;user={username};database=aerodb;port=3306;password={password}";
            //App.Conn = new MySqlConnection(connectionString);
            if (IsBusy)
            {
                return;
            }
            try
            {
                //App.Conn.Open();
                var _user = await userService.GetUser(username, password);
                User = _user;
            }
            catch
            {
                Status = "Login failed, tried again.";
            }
            finally
            {
                IsBusy = false;
            }
            if (User == null) { Status = "Login failed, tried again."; return; }
            App.CurrentUser = User;
            var viewModel = new HomeViewModel();
            Application.Current.MainPage = new Home(viewModel);
        }
    }
}
