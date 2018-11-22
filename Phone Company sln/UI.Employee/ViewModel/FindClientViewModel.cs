using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public Client localClientToUse { get; set; }

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
            // there's a new client here just to see that the binding works
            ClientsFound = new ObservableCollection<Client>
            {
                new Client { Adress = "asdasdsa", CallToCenter = 111, ClientTypeId = 1, ContactNumber = "12312312", Id = 1, LastName = "baba", Name = "asdasda", SignDate = DateTime.MinValue }
            };
        }

        private void CommandMoveToSelctedUser()
        {
            //await new MessageDialog("This Method will move you to a screen where you can chamge info on the user || The User ID IS " + localClientToUSe.Id).ShowAsync();

            _navigationService.NavigateTo(pageKey: "ClientsInfoPage", parameter: localClientToUse);
        }

        //This Method will get the id that user has entered
        //with OnChangeProperty so the list will be updated
        private async void CommandToGetUser()
        {
            await new MessageDialog("This Method will get the id that user has entered").ShowAsync();
            localClientToUse = ClientsFound.FirstOrDefault();
        }

        private void NavigateCommandActionToBack()
        {
            _navigationService.NavigateTo(pageKey: "EmployeeMainPage");
        }
    }
}