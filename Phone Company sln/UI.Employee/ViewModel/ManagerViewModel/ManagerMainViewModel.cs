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
        public RelayCommand NavigateCommandToAnnoyingCustomer { get; private set; }
        public RelayCommand NavigateCommandToAddNewPackage { get; private set; }
        public RelayCommand NavigateCommandToMostConnectedClient { get; private set; }
        public RelayCommand NavigateCommandToMostProfitableClient { get; private set; }

        public ManagerMainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToLogout = new RelayCommand(CommandToLogout);
            NavigateCommandToAnnoyingCustomer = new RelayCommand(CommandToAnnoyingCustomer);
            NavigateCommandToAddNewPackage = new RelayCommand(CommandToAddNewPackage);
            NavigateCommandToMostConnectedClient = new RelayCommand(CommandToMostConnectedClient);
            NavigateCommandToMostProfitableClient = new RelayCommand(CommandToMostProfitableClient);
        }

        private void CommandToMostProfitableClient()
        {
            _navigationService.NavigateTo("MostProfitableClientPage");
        }

        private void CommandToMostConnectedClient()
        {
            _navigationService.NavigateTo("MostConnectedClientPage");
        }

        private void CommandToAddNewPackage()
        {
            _navigationService.NavigateTo("AddNewPackagePage");
        }

        private void CommandToAnnoyingCustomer()
        {
            _navigationService.NavigateTo("MostAnnoyingCustomerPage");
        }

        private void CommandToLogout()
        {
            _navigationService.NavigateTo("MainView");
        }
    }
}