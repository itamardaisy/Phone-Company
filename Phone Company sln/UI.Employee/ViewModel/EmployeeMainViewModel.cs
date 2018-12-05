using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Employee.Helper;
using Windows.UI.Popups;

namespace UI.Employee.ViewModel
{
    internal class EmployeeMainViewModel
    {
        private readonly INavigationService _navigationService;
        public RelayCommand NavigateCommandToSearchForClient { get; private set; }
        public RelayCommand NavigateCommandToAddClient { get; set; }
        public RelayCommand NavigateCommandToLogout { get; private set; }

        public EmployeeMainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToSearchForClient = new RelayCommand(NavigateCommandActionToFindClient);
            NavigateCommandToAddClient = new RelayCommand(NavigateCommandActionToAddNewClient);
            NavigateCommandToLogout = new RelayCommand(CommandToLogout);
        }

        private void NavigateCommandActionToAddNewClient()
        {
            _navigationService.NavigateTo("AddNewClientPage");
        }

        private void NavigateCommandActionToFindClient()
        {
            _navigationService.NavigateTo("FindClientPage");
        }

        private void CommandToLogout()
        {
            _navigationService.NavigateTo("MainView");
        }
    }
}