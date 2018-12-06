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
    internal class AddNewClientViewModel
    {
        private readonly INavigationService _navigationService;
        public RelayCommand NavigateCommandToMainEmployeePage { get; private set; }
        public RelayCommand CommandToAddNewUser { get; set; }

        private const string BASE_ADDRESS = "http://localhost:50066/api/employee/";
        private HttpClient client;

        #region Client Info

        private Client newClient;
        public string ClientName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientAddress { get; set; }
        public ObservableCollection<ClientType> ClientTypes { get; set; }
        public int ChosenClientType { get; set; }
        public string ClientNumber { get; set; } 

        #endregion

        public AddNewClientViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToMainEmployeePage = new RelayCommand(NavigationCommandActionToMainEmployeePage);
            CommandToAddNewUser = new RelayCommand(AddNewUserAction);

            client = new HttpClient();
            client.BaseAddress = new Uri(BASE_ADDRESS);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            GetAllClientTypes();
        }

        
        /// <summary>
        /// Add New User Action
        /// </summary>
        private async void AddNewUserAction()
        {
            newClient = new Client
            {
                CallToCenter = 0,
                Adress = ClientAddress,
                ContactNumber = ClientNumber,
                LastName = ClientLastName,
                Name = ClientNumber,
                SignDate = DateTime.Now,
                ClientTypeId = ChosenClientType
            };

            var myUri = new Uri(BASE_ADDRESS + "AddNewClient", UriKind.Absolute);

            var message = await client.PostAsJsonAsync(myUri, newClient);

            using (HttpResponseMessage respone = message)
            {
                if (respone.IsSuccessStatusCode)
                {
                    await new MessageDialog("Client Has Been Added").ShowAsync();
                }
                await new MessageDialog("Bad Connection To The Server").ShowAsync();
            }
        }


        /// <summary>
        /// This function will add to the observableCollection all the client types
        /// </summary>
        private async void GetAllClientTypes()
        {
            var myUri = new Uri(BASE_ADDRESS + "GetClientTypes", UriKind.Absolute);

            var message = await client.GetAsync(myUri);

            using (HttpResponseMessage respone = message)
            {
                if (respone.IsSuccessStatusCode)
                {
                    var answer = await respone.Content.ReadAsAsync<ObservableCollection<ClientType>>();
                    if (answer != null)
                    {
                        ClientTypes = answer;
                    }

                }
                await new MessageDialog("Bad Connection To The Server").ShowAsync();
            }
        }

        /// <summary>
        /// Navigation To The Main Employee Page
        /// </summary>
        private void NavigationCommandActionToMainEmployeePage()
        {
            _navigationService.NavigateTo("EmployeeMainPage");
        }
    }
}