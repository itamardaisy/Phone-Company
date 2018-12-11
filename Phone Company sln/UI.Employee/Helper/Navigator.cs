using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Employee.Helper
{
    internal class Navigator
    {
        private readonly INavigationService _navigationService;

        public Navigator(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void NavigateToMainEmployeePage()
        {
            _navigationService.NavigateTo("EmployeeMainPage");
        }

        public void NavigateToMainManagerPage()
        {
            _navigationService.NavigateTo("ManagerMainPage");
        }

        public void NavigateToMainPage()
        {
            _navigationService.NavigateTo("MainView");
        }

        public void NavigateToFindClientPage()
        {
            _navigationService.NavigateTo("FindClientPage");
        }

        public void NavigateToAddNewClientPage()
        {
            _navigationService.NavigateTo("AddNewClientPage");
        }

        public void NavigateToMostProfitableClient()
        {
            _navigationService.NavigateTo("MostProfitableClientPage");
        }

        public void NavigateNavigaetToMostConnectedClient()
        {
            _navigationService.NavigateTo("MostConnectedClientPage");
        }

        public void NavigateToAddNewPackage()
        {
            _navigationService.NavigateTo("AddNewPackagePage");
        }

        public void NavigateToAnnoyingCustomer()
        {
            _navigationService.NavigateTo("MostAnnoyingCustomerPage");
        }

        public void NavigateBack()
        {
            _navigationService.GoBack();
        }
    }
}