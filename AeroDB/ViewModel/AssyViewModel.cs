using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AeroDB.View;
using AeroDB.Service;
using CommunityToolkit.Mvvm.Input;

namespace AeroDB.ViewModel
{
    public partial class AssyViewModel : BaseViewModel
    {

        PartService partService;
        public AssyViewModel(PartService partService) 
        {
            Title = "Assemblies";
            this.partService = partService;
            User = App.CurrentUser;
        }
    }
}
