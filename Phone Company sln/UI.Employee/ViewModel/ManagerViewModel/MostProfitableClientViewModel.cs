using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Employee.ViewModel
{
    internal class MostProfitableClientViewModel
    {
        private readonly INavigationService _navigationService;
        public RelayCommand NavigateCommandToManagerPage { get; private set; }

        public MostProfitableClientViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToManagerPage = new RelayCommand(GoBackCommand);
        }

        private void GoBackCommand()
        {
            _navigationService.NavigateTo(pageKey: "ManagerMainPage");
        }
    }
}