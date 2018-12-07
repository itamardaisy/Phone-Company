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
using UI.Employee.Models;
using Windows.UI.Popups;

namespace UI.Employee.ViewModel
{
    internal class MostProfitableClientViewModel
    {
        private readonly INavigationService _navigationService;
        public RelayCommand NavigateCommandToManagerPage { get; private set; }

        public ObservableCollection<Client> Clients { get; set; }
        private const string BASE_ADDRESS = "http://localhost:50066/api/employee/";
        private HttpClient client;

        public MostProfitableClientViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToManagerPage = new RelayCommand(GoBackCommand);

            client = new HttpClient();
            client.BaseAddress = new Uri(BASE_ADDRESS);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            GetClients();
        }

        private void GoBackCommand()
        {
            _navigationService.NavigateTo(pageKey: "ManagerMainPage");
        }

        private async void GetClients()
        {
            var myUri = new Uri(BASE_ADDRESS + "GetMostProfitableClient", UriKind.Absolute);

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
                await new MessageDialog("Bad Connection To The Server").ShowAsync();
            }
        }
    }
}