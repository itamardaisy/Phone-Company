using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using UI.Employee.Enums;
using UI.Employee.Models;

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

        private void NavigateCommandAction()
        {
            var user = new UserLogin
            {
                UserName = UserName,
                Password = Password
            };
            var itemAsJson = JsonConvert.SerializeObject(user);
            var content = new StringContent(itemAsJson);

            var response = client.PostAsync(BASE_ADDRESS + "api/Login", content).Result;

            if (expr)
            {
                _navigationService.NavigateTo("EmployeeMainPage");
            }
            _navigationService.NavigateTo("ManagerMainPage");
        }
    }
}