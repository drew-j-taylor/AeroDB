using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using AeroDB.View;

namespace AeroDB.ViewModel
{
    public partial class HomeViewModel : BaseViewModel
    {
        public HomeViewModel() 
        {
            Title = "Menu";
            User = App.CurrentUser;
        }

        [RelayCommand]
        async Task GoToPart()
        {
            var viewModel = new PartViewModel(new Service.PartService());
            Application.Current.MainPage = new Part(viewModel);
        }

        [RelayCommand]
        async Task GoToAssy()
        {
            var viewModel = new AssyViewModel(new Service.PartService());
            Application.Current.MainPage = new AssyView(viewModel);
        }
    }
}
