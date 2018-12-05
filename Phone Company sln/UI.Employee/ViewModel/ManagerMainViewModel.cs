using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Employee.ViewModel
{
    internal class ManagerMainViewModel
    {
        public INavigationService _navigationService { get; set; }
        public RelayCommand NavigateCommandToLogout { get; private set; }

        public ManagerMainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToLogout = new RelayCommand(CommandToLogout);
        }

        private void CommandToLogout()
        {
            _navigationService.NavigateTo("MainView");
        }
    }
}