using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Employee.Models;
using Windows.UI.Popups;

namespace UI.Employee.ViewModel
{
    internal class AddNewClientViewModel
    {
        private readonly INavigationService _navigationService;
        public RelayCommand NavigateCommandToMainEmployeePage { get; private set; }
        public RelayCommand CommandToAddNewUser { get; set; }

        public string ClientName { get; set; }

        public string ClientLastName { get; set; }

        public string ClientAddress { get; set; }

        public ObservableCollection<ClientType> ClientTypes { get; set; }

        public string ClientNumber { get; set; }

        public AddNewClientViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToMainEmployeePage = new RelayCommand(NavigationCommandActionToMainEmployeePage);
            CommandToAddNewUser = new RelayCommand(AddNewUserAction);
        }

        //Add new User Action
        private async void AddNewUserAction()
        {
            await new MessageDialog("Here There Will Be A Call To The Server To Add New User").ShowAsync();
        }

        private void NavigationCommandActionToMainEmployeePage()
        {
            _navigationService.NavigateTo(pageKey: "EmployeeMainPage");
        }

        //This function will add to the observableCollection all the client types
        private void GetAllClientTypes()
        {
            //an example: in this one is with the use of WCF

            // creating a new task that go to the service and activate the function that gets all the type
            //var task = Task.Factory.StartNew(() => _service.GetClientTypes());

            //here the ClientTypes Observable is the results of the task
            //ClientTypes = new ObservableCollection<ClientType>(task.Result.Result);
        }
    }
}