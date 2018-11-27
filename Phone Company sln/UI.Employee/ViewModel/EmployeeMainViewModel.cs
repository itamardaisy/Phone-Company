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
        private readonly IFrameNavigationService _navigationService;
        public RelayCommand NavigateCommandToSearchForClient { get; private set; }
        public RelayCommand NavigateCommandToAddClient { get; set; }

        public EmployeeMainViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToSearchForClient = new RelayCommand(NavigateCommandActionToFindClient);
            NavigateCommandToAddClient = new RelayCommand(NavigateCommandActionToAddNewClient);
        }

        private void NavigateCommandActionToAddNewClient()
        {
            _navigationService.NavigateTo("AddNewClientPage");
        }

        private void NavigateCommandActionToFindClient()
        {
            _navigationService.NavigateTo("FindClientPage");
        }
    }
}