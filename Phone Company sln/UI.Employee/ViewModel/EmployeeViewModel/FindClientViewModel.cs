using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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
        #region Fields

        private readonly INavigationService _navigationService;

        public int SearchID { get; set; }
        public Client SelctedClient { get; set; }

        private const string BASE_ADDRESS = "http://localhost:50066/api/employee/";
        private HttpClient client;

        public Messenger MessengerInstance { get; set; }

        private Navigator _navigator;

        public ObservableCollection<Client> ClientsFound { get; set; }

        public RelayCommand CommandToGetUserByID { get; private set; }
        public RelayCommand NavigateCommandToBack { get; private set; }
        public RelayCommand CommandToMoveToSelectedUser { get; private set; }

        #endregion Fields

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="navigationService"></param>
        public FindClientViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigator = new Navigator(_navigationService);
            NavigateCommandToBack = new RelayCommand(NavigateCommandActionToBack);
            CommandToGetUserByID = new RelayCommand(CommandToGetUser);
            CommandToMoveToSelectedUser = new RelayCommand(CommandMoveToSelctedUser);

            MessengerInstance = new Messenger();

            client = HttpClientHelper.CreateHttpClient();
        }

        /// <summary>
        /// Command to move to the more info on the client page by selecting him/her from the list
        /// </summary>
        private void CommandMoveToSelctedUser()
        {
            SelctedClient = ClientsFound.FirstOrDefault();
            MessengerInstance.Send("1212", SelctedClient);
            _navigationService.NavigateTo("ClientsInfoPage", SelctedClient);
        }

        /// <summary>
        /// This Method will get the id that user has entered
        /// with OnChangeProperty so the list will be updated
        /// </summary>
        private async void CommandToGetUser()
        {
            var myUri = new Uri(BASE_ADDRESS + "GetClient", UriKind.Absolute);

            var message = await client.GetAsync(myUri + $"?clientId={SearchID}");

            using (HttpResponseMessage respone = message)
            {
                if (respone.IsSuccessStatusCode)
                {
                    ClientsFound = await respone.Content.ReadAsAsync<ObservableCollection<Client>>();
                }
                else
                    await new MessageDialog("Bad Connection To The Server").ShowAsync();
            }
        }

        /// <summary>
        /// Navigation command to go to the main employee page
        /// </summary>
        private void NavigateCommandActionToBack()
        {
            _navigator.NavigateToMainEmployeePage();
        }
    }
}