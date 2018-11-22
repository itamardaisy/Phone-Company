using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Employee.Helper;
using UI.Employee.Models;
using Windows.UI.Xaml.Navigation;

namespace UI.Employee.ViewModel
{
    internal class ClientsInfoViewModel
    {
        private readonly INavigationService _navigationService;

        public Client newClient { get; set; }

        public ClientsInfoViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            //newClient = navigationService.Parameter as Client;
        }
    }
}