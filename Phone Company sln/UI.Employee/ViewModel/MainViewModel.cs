using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UI.Employee.Enums;
using UI.Employee.Models;
using Windows.UI.Popups;

namespace UI.Employee.ViewModel
{
    internal class MainViewModel
    {
        private readonly INavigationService _navigationService;
        public RelayCommand NavigateCommandToMainEmployeePage { get; private set; }
        private const string BASE_ADDRESS = "http://localhost:50066/";
        private HttpClient client;

        public string UserName { get; set; }
        public string Password { get; set; }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToMainEmployeePage = new RelayCommand(NavigateCommandAction);
            client = new HttpClient();
            client.BaseAddress = new Uri(BASE_ADDRESS);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void NavigateCommandAction()
        {
            var user = new User
            {
                Name = UserName,
                Password = Password
            };

            var myUri = new Uri(BASE_ADDRESS + "api/Login", UriKind.Absolute);
            var message = await client.PostAsJsonAsync<User>(myUri, user);

            using (HttpResponseMessage respone = message)
            {
                if (respone.IsSuccessStatusCode)
                {
                    User userFromDB = await respone.Content.ReadAsAsync<User>();
                    if (userFromDB != null)
                    {
                        if (userFromDB.Type == UserType.Emploee)
                        {
                            _navigationService.NavigateTo("EmployeeMainPage");
                        }
                        _navigationService.NavigateTo("ManagerMainPage");
                    }
                    else
                        await new MessageDialog("User does not exist").ShowAsync();
              
                }
                await new MessageDialog("Bad Connection To The Server").ShowAsync();
            }
        }
    }
}