using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Employee.ViewModel
{
    internal class MainViewModel
    {
        private readonly INavigationService _navigationService;
        public RelayCommand NavigateCommandToMainEmployeePage { get; private set; }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToMainEmployeePage = new RelayCommand(NavigateCommandAction);
        }

        private void NavigateCommandAction()
        {
            _navigationService.NavigateTo(pageKey: "EmployeeMainPage");
        }
    }
}