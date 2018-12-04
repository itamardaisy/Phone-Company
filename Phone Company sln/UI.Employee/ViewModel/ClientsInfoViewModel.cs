using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
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
    internal class ClientsInfoViewModel
    {
        private readonly INavigationService _navigationService;

        public RelayCommand UpdateClient { get; set; }
        public RelayCommand DeleteClient { get; set; }

        private static Client newClient { get; set; }

        public ClientsInfoViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            UpdateClient = new RelayCommand(UpdateClientCommand);
            DeleteClient = new RelayCommand(DeleteClientCommand);
        }

        /// <summary>
        /// This Method Will Grab The Id of the Client and send the request
        /// </summary>
        private void DeleteClientCommand()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This will grab the data and send it to the DB for update
        /// </summary>
        private void UpdateClientCommand()
        {
            throw new NotImplementedException();
        }

        public ClientsInfoViewModel()
        {
            UpdateClient = new RelayCommand(UpdateClientCommand);
            DeleteClient = new RelayCommand(DeleteClientCommand);
        }

        private static void GetClientFromBhind(Client client)
        {
            newClient = client;
        }
    }
}