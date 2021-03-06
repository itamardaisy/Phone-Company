﻿using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using UI.Employee.Enums;
using UI.Employee.Helper;
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

        private Navigator _navigator;

        public string UserName { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="navigationService"></param>
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigator = new Navigator(_navigationService);
            NavigateCommandToMainEmployeePage = new RelayCommand(NavigateCommandAction);

            client = HttpClientHelper.CreateHttpClient();
        }

        /// <summary>
        /// Because I wanted to use one UI to both employees and managers I created this action
        /// This action sends the username and password to the server to be checked if this user exist in the DB
        /// And the function returns the user, each user as a type (employee/manager) by the type of the returned
        /// User I send him to is correct page.
        /// </summary>
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
                            _navigator.NavigateToMainEmployeePage();

                        _navigator.NavigateToMainManagerPage();
                    }
                    else
                        await new MessageDialog("User does not exist").ShowAsync();
                }
                else
                    await new MessageDialog("Bad Connection To The Server").ShowAsync();
            }
        }
    }
}