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
    internal class EmployeeMainViewModel
    {
        private readonly INavigationService _navigationService;
        public RelayCommand NavigateCommandToSearchForClient { get; private set; }

        public EmployeeMainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToSearchForClient = new RelayCommand(NavigateCommandActionToFindClient);
        }

        private void NavigateCommandActionToFindClient()
        {
            _navigationService.NavigateTo(pageKey: "FindClientPage");
        }
    }
}