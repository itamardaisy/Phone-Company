using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using UI.Employee.Helper;
using UI.Employee.Models;
using Windows.UI.Popups;

namespace UI.Employee.ViewModel
{
    internal class AddNewPackageViewModel : ViewModelBase
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
        public string TotalPrice { get; set; }
        public string MaxSMSs { get; set; }
        public string MaxMinuts { get; set; }
        public string FixedPrice { get; set; }
        public string DisscountPrecentage { get; set; }

        #endregion Package Info

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="navigationService"></param>
        public AddNewPackageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToManagerPage = new RelayCommand(GoBackCommand);
            NavigateCommandToAddNewPackage = new RelayCommand(CommandToAddNewPackage);

            client = HttpClientHelper.CreateHttpClient();
        }

        /// <summary>
        /// Command to add new package
        /// </summary>
        private async void CommandToAddNewPackage()
        {
            NewPackage = PackageValidate();

            if (NewPackage != null)
            {
                var myUri = new Uri(BASE_ADDRESS + "AddNewPackage", UriKind.Absolute);

                var message = await client.PostAsJsonAsync(myUri, NewPackage);

                using (HttpResponseMessage respone = message)
                {
                    if (respone.IsSuccessStatusCode)
                    {
                        await new MessageDialog("Package Has Been Added").ShowAsync();
                    }
                    else
                        await new MessageDialog("Bad Connection To The Server").ShowAsync();
                }
            }
            else
            {
                await new MessageDialog("Some Of The Fields Re Incorrect").ShowAsync();
            }
        }

        /// <summary>
        /// Navigation to the main manager page
        /// </summary>
        private void GoBackCommand()
        {
            _navigationService.NavigateTo(pageKey: "ManagerMainPage");
        }

        /// <summary>
        /// Validate if the entered fields are correct
        /// </summary>
        /// <returns> If the package validate it will return it </returns>
        private Package PackageValidate()
        {
            int maxSMSs;
            double totalPrice;
            int maxMinuts;
            double fixedPrice;
            int disscountPrecentage;

            var NewPackage = new Package();

            bool isTotalPrice = double.TryParse(TotalPrice, out totalPrice);
            bool isMaxSMSs = int.TryParse(MaxSMSs, out maxSMSs);
            bool isMaxMinuts = int.TryParse(MaxMinuts, out maxMinuts);
            bool isFixedPrice = double.TryParse(FixedPrice, out fixedPrice);
            bool isDisscountPrecentage = int.TryParse(DisscountPrecentage, out disscountPrecentage);

            if (isTotalPrice == true || isMaxSMSs == true || isMaxMinuts == true ||
                isFixedPrice == true || isDisscountPrecentage == true)
            {
                NewPackage.MostCallNumber = _isMostCallNumbeChecked;
                NewPackage.InsideFamilyCall = _isInsideFamilyCallChecked;
                NewPackage.SelectedNumber = _isSelectedNumberChecked;
                NewPackage.TotalPrice = totalPrice;
                NewPackage.MaxSMSs = maxSMSs;
                NewPackage.MaxMinute = maxMinuts;
                NewPackage.FixedPrice = fixedPrice;
                NewPackage.DisscountPrecentage = disscountPrecentage;
                return NewPackage;
            }
            else
            {
                return null;
            }
        }
    }
}