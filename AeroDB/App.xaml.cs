using AeroDB.Model;
using AeroDB.View;
using AeroDB.ViewModel;
using AeroDB.Service;
using MySql.Data.MySqlClient;


namespace AeroDB
{
    public partial class App : Application
    {
        public static AeroUser CurrentUser { get; set; }
        public static MySqlConnection Conn { get; set; }
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            var userService = new UserService();
            var loginViewModel = new LoginViewModel(userService);
            MainPage = new Login(loginViewModel);
        }
    }
}