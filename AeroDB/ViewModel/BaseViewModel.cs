using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Windows.System;
using AeroDB.Model;

namespace AeroDB.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        // Indicates whether a process is currently running or the ViewModel is in a "busy" state.
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        // Represents the current user associated with this ViewModel.
        [ObservableProperty]
        public AeroUser user;

        // Represents the title associated with this ViewModel.
        [ObservableProperty]
        string title;

        /// <summary>
        /// Gets a value indicating whether the ViewModel is not in a "busy" state.
        /// </summary>
        public bool IsNotBusy => !IsBusy;
    }
}
