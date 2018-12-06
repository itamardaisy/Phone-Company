using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UI.Employee.Models;
using UI.Employee.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UI.Employee.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClientsInfoPage : Page
    {
        public ClientsInfoPage()
        {
            this.InitializeComponent();
        }

        private Client newClient { get; set; }
     

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            newClient = e.Parameter as Client;  // "My data"
            clientName.Text = newClient.Name.ToString();
            clientLastName.Text = newClient.LastName.ToString();
            clientAddress.Text = newClient.Adress.ToString();
            clientNumber.Text = newClient.ContactNumber.ToString();
            clientType.SelectedIndex = newClient.ClientTypeId;
            // clientsInfoViewModel.newClientFrom = newClient;

            base.OnNavigatedTo(e);
        }
    }
}