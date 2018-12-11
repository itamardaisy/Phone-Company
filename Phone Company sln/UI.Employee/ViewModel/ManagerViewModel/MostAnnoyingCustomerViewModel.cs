using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UI.Employee.Helper;
using UI.Employee.Models;
using Windows.UI.Popups;

namespace UI.Employee.ViewModel
{
    internal class MostAnnoyingCustomerViewModel
    {
        private readonly INavigationService _navigationService;
        public RelayCommand NavigateCommandToManagerPage { get; private set; }

        public ObservableCollection<Client> Clients { get; set; }
        private const string BASE_ADDRESS = "http://localhost:50066/api/manager/";
        private HttpClient client;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="navigationService"></param>
        public MostAnnoyingCustomerViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToManagerPage = new RelayCommand(GoBackCommand);

            client = HttpClientHelper.CreateHttpClient();

            GetClients();
        }

        /// <summary>
        /// Navigation command to go back to the main manger page
        /// </summary>
        private void GoBackCommand()
        {
            _navigationService.NavigateTo(pageKey: "ManagerMainPage");
        }

        /// <summary>
        /// Command to get the most annoying client
        /// and put them/him in the observableCollection called "Clients"
        /// </summary>
        private async void GetClients()
        {
            var myUri = new Uri(BASE_ADDRESS + "GetMostAnnoyingClient", UriKind.Absolute);

            var message = await client.GetAsync(myUri);

            using (HttpResponseMessage respone = message)
            {
                if (respone.IsSuccessStatusCode)
                {
                    var answer = await respone.Content.ReadAsAsync<ObservableCollection<Client>>();
                    if (answer != null)
                    {
                        Clients = answer;
                    }
                }
                else
                    await new MessageDialog("Bad Connection To The Server").ShowAsync();
            }
        }
    }
}