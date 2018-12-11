using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
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
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UI.Employee.ViewModel
{
    internal class ClientsInfoViewModel
    {
        #region Fields

        private readonly INavigationService _navigationService;

        public RelayCommand UpdateClient { get; set; }
        public RelayCommand DeleteClient { get; set; }
        public RelayCommand CommandToGoBack { get; set; }

        private Navigator _navigator;

        private MessageDialog messageDialog;
        public Messenger MessengerInstance { get; set; }

        public Client newClientFrom { get; set; }
        public ObservableCollection<ClientType> ClientTypes { get; set; }

        private const string BASE_ADDRESS = "http://localhost:50066/api/employee/";
        private HttpClient client;

        #endregion Fields

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="navigationService"></param>
        public ClientsInfoViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigator = new Navigator(_navigationService);
            UpdateClient = new RelayCommand(UpdateClientCommand);
            DeleteClient = new RelayCommand(DeleteClientCommand);
            CommandToGoBack = new RelayCommand(GoBackCommand);

            client = HttpClientHelper.CreateHttpClient();

            MessengerInstance = new Messenger();
            newClientFrom = new Client();
            MessengerInstance.Register<Client>(this, "123456", (a) => { GetTheUser(a); });
        }

        private void GetTheUser(Client newClientFrom)
        {
            this.newClientFrom = newClientFrom;
        }

        /// <summary>
        /// Navigation command to go back to the employee main page
        /// </summary>
        private void GoBackCommand()
        {
            _navigator.NavigateToMainEmployeePage();
        }

        /// <summary>
        /// This Method Will Grab The Id of the Client and send the request
        /// </summary>
        private async void DeleteClientCommand()
        {
            var myUri = new Uri(BASE_ADDRESS + "DeleteClient", UriKind.Absolute);

            var message = await client.DeleteAsync(myUri + $"?id={newClientFrom.Id}");

            using (HttpResponseMessage respone = message)
            {
                if (respone.IsSuccessStatusCode)
                {
                    var answer = await respone.Content.ReadAsAsync<bool>();
                    if (answer == true)
                    {
                        messageDialog = new MessageDialog("Client Has Benn Deleted");
                        messageDialog.Commands.Add(new UICommand("Ok", new UICommandInvokedHandler(this.CommandInvokedHandler)));
                        await messageDialog.ShowAsync();
                    }
                }
                else
                    await new MessageDialog("Bad Connection To The Server").ShowAsync();
            }
        }

        /// <summary>
        /// This will grab the data and send it to the DB for update
        /// </summary>
        private async void UpdateClientCommand()
        {
            var myUri = new Uri(BASE_ADDRESS + "UpdateClientDetails", UriKind.Absolute);

            var message = await client.PutAsJsonAsync(myUri, newClientFrom);

            using (HttpResponseMessage respone = message)
            {
                if (respone.IsSuccessStatusCode)
                {
                    var answer = await respone.Content.ReadAsAsync<bool>();
                    if (answer == true)
                    {
                        messageDialog = new MessageDialog("Client Has Benn Deleted");
                        messageDialog.Commands.Add(new UICommand("Ok", new UICommandInvokedHandler(this.CommandInvokedHandler)));
                        await messageDialog.ShowAsync();
                    }
                }
                else
                    await new MessageDialog("Bad Connection To The Server").ShowAsync();
            }
        }

        /// <summary>
        /// Command to get all the client types and put
        /// them in the observableCollection called "ClientTypes"
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
                else
                    await new MessageDialog("Bad Connection To The Server").ShowAsync();
            }
        }

        /// <summary>
        /// Add UI command to the MessageDialog
        /// </summary>
        /// <param name="command"></param>
        private void CommandInvokedHandler(IUICommand command)
        {
            GoBackCommand();
        }
    }
}