using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Employee.Helper;

namespace UI.Employee.ViewModel
{
    internal class ManagerMainViewModel
    {
        #region Fields

        public INavigationService _navigationService { get; set; }
        public RelayCommand NavigateCommandToLogout { get; private set; }
        public RelayCommand NavigateCommandToAnnoyingCustomer { get; private set; }
        public RelayCommand NavigateCommandToAddNewPackage { get; private set; }
        public RelayCommand NavigateCommandToMostConnectedClient { get; private set; }
        public RelayCommand NavigateCommandToMostProfitableClient { get; private set; }

        private Navigator _navigator;

        #endregion Fields

        public ManagerMainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigator = new Navigator(_navigationService);

            NavigateCommandToLogout = new RelayCommand(CommandToLogout);
            NavigateCommandToAnnoyingCustomer = new RelayCommand(CommandToAnnoyingCustomer);
            NavigateCommandToAddNewPackage = new RelayCommand(CommandToAddNewPackage);
            NavigateCommandToMostConnectedClient = new RelayCommand(CommandToMostConnectedClient);
            NavigateCommandToMostProfitableClient = new RelayCommand(CommandToMostProfitableClient);
        }

        private void CommandToMostProfitableClient()
        {
            _navigator.NavigateToMostProfitableClient();
        }

        private void CommandToMostConnectedClient()
        {
            _navigator.NavigateNavigaetToMostConnectedClient();
        }

        private void CommandToAddNewPackage()
        {
            _navigator.NavigateToAddNewPackage();
        }

        private void CommandToAnnoyingCustomer()
        {
            _navigator.NavigateToAnnoyingCustomer();
        }

        private void CommandToLogout()
        {
            _navigator.NavigateToMainPage();
        }
    }
}