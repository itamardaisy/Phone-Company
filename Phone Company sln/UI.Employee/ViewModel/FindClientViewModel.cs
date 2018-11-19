using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace UI.Employee.ViewModel
{
    internal class FindClientViewModel
    {
        private readonly INavigationService _navigationService;

        public int SearchID { get; set; }

        public List<string> ClientsFound { get; set; }

        public RelayCommand CommandToGetUserByID { get; private set; }
        public RelayCommand NavigateCommandToBack { get; private set; }

        public FindClientViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToBack = new RelayCommand(NavigateCommandActionToBack);
            CommandToGetUserByID = new RelayCommand(CommandToGetUser);
        }

        //This Method will get the id that user has entered
        private async void CommandToGetUser()
        {
            await new MessageDialog("This Method will get the id that user has entered").ShowAsync();
        }

        private void NavigateCommandActionToBack()
        {
            _navigationService.NavigateTo(pageKey: "EmployeeMainPage");
        }
    }
}