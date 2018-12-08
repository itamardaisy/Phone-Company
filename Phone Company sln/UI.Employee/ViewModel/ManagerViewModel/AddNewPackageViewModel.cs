using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using UI.Employee.Models;
using Windows.UI.Popups;

namespace UI.Employee.ViewModel
{
    internal class AddNewPackageViewModel: ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public RelayCommand NavigateCommandToAddNewPackage { get; set; }
        public RelayCommand NavigateCommandToManagerPage { get; private set; }

        private const string BASE_ADDRESS = "http://localhost:50066/api/manager/";
        private HttpClient client;

        #region Package Info

        public Package NewPackage { get; set; }

        private bool _isMostCallNumbeChecked;
        public bool IsMostCallNumbeChecked
        {
            get { return _isMostCallNumbeChecked; }
            set
            {
                if (_isMostCallNumbeChecked == value) return;

                _isMostCallNumbeChecked = value;
            }
        }

        private bool _isInsideFamilyCallChecked;
        public bool IsInsideFamilyCallChecked
        {
            get { return _isInsideFamilyCallChecked; }
            set
            {
                if (_isInsideFamilyCallChecked = value) return;

                _isInsideFamilyCallChecked = value;
            }
        }

        private bool _isSelectedNumberChecked;
        public bool IsSelectedNumberChecked
        {
            get { return _isSelectedNumberChecked; }
            set
            {
                if (_isSelectedNumberChecked = value) return;

                _isSelectedNumberChecked = value;
            }
        }

        public string Name { get; set; }
        public double TotalPrice { get; set; }
        public int MaxSMSs { get; set; }
        public int MaxMinuts { get; set; }
        public double FixedPrice { get; set; }
        public int DisscountPrecentage { get; set; } 

        #endregion

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="navigationService"></param>
        public AddNewPackageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToManagerPage = new RelayCommand(GoBackCommand);
            NavigateCommandToAddNewPackage = new RelayCommand(CommandToAddNewPackage);

            #region Configure httpClient for the web api request

            client = new HttpClient();
            client.BaseAddress = new Uri(BASE_ADDRESS);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 

            #endregion
        }

        /// <summary>
        /// Command to add new package
        /// </summary>
        private async void CommandToAddNewPackage()
        {
            NewPackage = new Package
            {
                MostCallNumber = _isMostCallNumbeChecked,
                InsideFamilyCall = _isInsideFamilyCallChecked,
                SelectedNumber = _isSelectedNumberChecked,       
                
            };

            var myUri = new Uri(BASE_ADDRESS + "AddNewPackage", UriKind.Absolute);

            var message = await client.PostAsJsonAsync(myUri, NewPackage);

            using (HttpResponseMessage respone = message)
            {
                if (respone.IsSuccessStatusCode)
                {
                    await new MessageDialog("Package Has Been Added").ShowAsync();
                }
                await new MessageDialog("Bad Connection To The Server").ShowAsync();
            }
        }
     
        /// <summary>
        /// Navigation to the main manager page
        /// </summary>
        private void GoBackCommand()
        {
            _navigationService.NavigateTo(pageKey: "ManagerMainPage");
        }
    }
}