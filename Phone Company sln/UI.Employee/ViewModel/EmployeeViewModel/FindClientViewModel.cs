using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    internal class FindClientViewModel
    {
        private readonly INavigationService _navigationService;

        public int SearchID { get; set; }
        public Client SelctedClient { get; set; }

        private const string BASE_ADDRESS = "http://localhost:50066/api/employee/";
        private HttpClient client;

        public ObservableCollection<Client> ClientsFound { get; set; }

        public RelayCommand CommandToGetUserByID { get; private set; }
        public RelayCommand NavigateCommandToBack { get; private set; }
        public RelayCommand CommandToMoveToSelectedUser { get; private set; }

        public FindClientViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToBack = new RelayCommand(NavigateCommandActionToBack);
            CommandToGetUserByID = new RelayCommand(CommandToGetUser);
            CommandToMoveToSelectedUser = new RelayCommand(CommandMoveToSelctedUser);

            ClientsFound = new ObservableCollection<Client>()
            {
                new Client{Id = 1,Adress = "asdasd",CallToCenter = 12,ClientTypeId = 1,
                    ContactNumber = "2131231",LastName = "bababa",Name = "bababa",SignDate = DateTime.Now}
            };

            client = new HttpClient();
            client.BaseAddress = new Uri(BASE_ADDRESS);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void CommandMoveToSelctedUser()
        {
            SelctedClient = ClientsFound.FirstOrDefault();
            _navigationService.NavigateTo("ClientsInfoPage", SelctedClient);
        }

        /// <summary>
        /// This Method will get the id that user has entered
        /// with OnChangeProperty so the list will be updated
        /// </summary>
        private async void CommandToGetUser()
        {
            //SelectedUser = ClientsFound.FirstOrDefault();

            var myUri = new Uri(BASE_ADDRESS + "GetClient", UriKind.Absolute);

            var message = await client.GetAsync(myUri + $"?clientId={SearchID}");

            using (HttpResponseMessage respone = message)
            {
                if (respone.IsSuccessStatusCode)
                {
                    ClientsFound = await respone.Content.ReadAsAsync<ObservableCollection<Client>>();
                }
                await new MessageDialog("Bad Connection To The Server").ShowAsync();
            }
        }

        private void NavigateCommandActionToBack()
        {
            _navigationService.NavigateTo(pageKey: "EmployeeMainPage");
        }
    }
}