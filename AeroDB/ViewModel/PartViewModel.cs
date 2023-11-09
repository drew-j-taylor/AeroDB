using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AeroDB.Model;
using AeroDB.View;
using AeroDB.Service;
using System.Collections.ObjectModel;

namespace AeroDB.ViewModel
{
    public partial class PartViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string partNum;

        [ObservableProperty]
        public Model.Part detailPart;

        [ObservableProperty]
        public string status;

        [ObservableProperty] 
        public string addPartNumber;

        [ObservableProperty]
        public string addPartDescription;

        [ObservableProperty]
        public string addPartProgram;

        [ObservableProperty]
        public string addPartSource;

        [ObservableProperty]
        public ObservableCollection<string> programs;

        [ObservableProperty]
        public ObservableCollection<string> sources;

        PartService partService;
        public PartViewModel(PartService partService) 
        {
            Title = "Part";
            Status = "";
            AddPartDescription = string.Empty;
            AddPartNumber = string.Empty;
            AddPartProgram = string.Empty;
            AddPartSource = string.Empty;
            User = App.CurrentUser;
            this.partService = partService;

            var _programs = partService.GetPrograms();
            Programs = _programs;
            var _sources = partService.GetSource();
            Sources = _sources;
        }

        [RelayCommand]
        async Task GetPart(string partId)
        {
            if (IsBusy)
            {
                return;
            }
            try
            {
                //App.Conn.Open();
                var _part = await partService.GetPart(partId);
                DetailPart = _part;
                //var _programs = partService.GetPrograms();
                //Programs = _programs;
                //var _sources = partService.GetSource();
                //Sources = _sources;
                Status = "";
            }
            catch
            {
                Status = "Part not found, tried again.";
            }
            finally
            {
                IsBusy = false;
            }
            if (DetailPart == null) { Status = "Part not found, tried again."; return; }
        }

        [RelayCommand]
        async Task EditPart()
        {
            int edit = 0;
            if (IsBusy) { return; }
            if (DetailPart == null) { Status = ""; return; }
            try
            {
                edit = partService.EditPart(DetailPart.PartNumber, DetailPart.PartDescription, DetailPart.ProgramCode, DetailPart.SourceCode);
                if (edit < 1) 
                { 
                    Status = "Edit failed, try again"; 
                    return; 
                }
                var _part = await partService.GetPart(DetailPart.PartNumber);
                DetailPart = _part;
                Status = "Part edited successfully.";
            }
            catch
            {
                Status = "Edit failed, try again";
            }
            finally { IsBusy = false; }
            if (edit < 1) { Status = "Edit failed, try again"; return; }
        }

        [RelayCommand]
        async Task AddPart()
        {
            int add = 0;
            if (IsBusy) { return; }
            try
            {
                var _part = await partService.GetPart(AddPartNumber);
                if (_part != null)
                {
                    Status = "Part number already exists.";
                    return;
                }
                add = partService.AddPart(AddPartNumber, AddPartDescription, AddPartProgram, AddPartSource);
                if (add < 1)
                {
                    Status = "Add failed, try again";
                    return;
                }
                _part = await partService.GetPart(AddPartNumber);
                DetailPart = _part;
                Status = "New part added successfully.";
            }
            catch
            {
                Status = "Add failed, try again";
            }
            finally { IsBusy = false; }
            if (add < 1) { Status = "Add failed, try again"; return; }
        }

        [RelayCommand]
        async Task ReturnHome()
        {
            if (IsBusy) { return; }
            var viewModel = new HomeViewModel();
            Application.Current.MainPage = new Home(viewModel);
        }
    }
}
