using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Employee.Helper;
using UI.Employee.Models;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UI.Employee.ViewModel
{
    internal class ClientsInfoViewModel : Page
    {
        private readonly INavigationService _navigationService;

        public Client newClient { get; set; }

        public ClientsInfoViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            newClient = e.Parameter as Client;  // "My data"
            base.OnNavigatedTo(e);
        }
    }
}