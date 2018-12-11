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

        private Navigator _navigator;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="navigationService"></param>
        public EmployeeMainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigator = new Navigator(_navigationService);
            NavigateCommandToSearchForClient = new RelayCommand(NavigateCommandActionToFindClient);
            NavigateCommandToAddClient = new RelayCommand(NavigateCommandActionToAddNewClient);
            NavigateCommandToLogout = new RelayCommand(CommandToLogout);
        }

        /// <summary>
        /// Navigation command to move to the AddNewClientPage page
        /// </summary>
        private void NavigateCommandActionToAddNewClient()
        {
            _navigator.NavigateToAddNewClientPage();
        }

        /// <summary>
        /// Navigation command to move to the FindClientPage page
        /// </summary>
        private void NavigateCommandActionToFindClient()
        {
            _navigator.NavigateToFindClientPage();
        }

        /// <summary>
        /// Navigation command to move to the MainView page (logout)
        /// </summary>
        private void CommandToLogout()
        {
            _navigator.NavigateToMainPage();
        }
    }
}