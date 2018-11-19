using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Employee.Models;
using Windows.UI.Popups;

namespace UI.Employee.ViewModel
{
    internal class FindClientViewModel
    {
        private readonly INavigationService _navigationService;

        public int SearchID { get; set; }

        public List<Client> ClientsFound { get; set; }

        public RelayCommand CommandToGetUserByID { get; private set; }
        public RelayCommand NavigateCommandToBack { get; private set; }

        public FindClientViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToBack = new RelayCommand(NavigateCommandActionToBack);
            CommandToGetUserByID = new RelayCommand(CommandToGetUser);
            // there's a new client here just to see that the binding works
            ClientsFound = new List<Client>
            {
                new Client { Adress = "asdasdsa", CallToCenter = 111, ClientTypeId = 1, ContactNumber = "12312312", Id = 1, LastName = "baba", Name = "asdasda", SignDate = DateTime.MinValue }
            };
        }

        //This Method will get the id that user has entered
        //with OnChangeProperty so the list will be updated
        private async void CommandToGetUser()
        {
            await new MessageDialog("This Method will get the id that user has entered").ShowAsync();
        }

        private void NavigateCommandActionToBack()
        {
            _navigationService.NavigateTo(pageKey: "EmployeeMainPage");
        }
    }
}