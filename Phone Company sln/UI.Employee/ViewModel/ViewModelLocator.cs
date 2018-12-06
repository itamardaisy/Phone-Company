using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Employee.Helper;
using Windows.UI.Xaml.Controls;

namespace UI.Employee.ViewModel
{
    internal class ViewModelLocator
    {
        #region PageKey for navigation Service

        private const string MainPageKey = "MainView";

        #region Employee Pages Keys

        private const string EmployeeMainPageKey = "EmployeeMainPage";
        private const string FindClientPageKey = "FindClientPage";
        private const string AddNewClientPageKey = "AddNewClientPage";
        private const string ClientsInfoPageKey = "ClientsInfoPage";

        #endregion Employee Pages Keys

        #region Manager Pages Keys

        private const string ManagerMainPageKey = "ManagerMainPage";
        private const string AddNewPackagePageKey = "AddNewPackagePage";
        private const string MostAnnoyingCustomerPageKey = "MostAnnoyingCustomerPage";
        private const string MostConnectedClientPageKey = "MostConnectedClientPage";
        private const string MostProfitableClientPageKey = "MostProfitableClientPage";

        #endregion Manager Pages Keys

        #endregion PageKey for navigation Service

        /// <summary>
        /// Registering all the Views in ViewLocator In The Constructor
        /// </summary>
        public ViewModelLocator()
        {
            #region ViewModel Register

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #region Employee Views

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<EmployeeMainViewModel>();
            SimpleIoc.Default.Register<FindClientViewModel>();
            SimpleIoc.Default.Register<AddNewClientViewModel>();
            SimpleIoc.Default.Register<ClientsInfoViewModel>();

            #endregion Employee Views

            #region Manager Views

            SimpleIoc.Default.Register<ManagerMainViewModel>();
            SimpleIoc.Default.Register<AddNewPackageViewModel>();
            SimpleIoc.Default.Register<MostAnnoyingCustomerViewModel>();
            SimpleIoc.Default.Register<MostConnectedClientViewModel>();
            SimpleIoc.Default.Register<MostProfitableClientViewModel>();

            #endregion Manager Views

            #endregion ViewModel Register

            SetUpNavigation();
        }

        /// <summary>
        /// Configuring each PageKey for a page
        /// </summary>
        private void SetUpNavigation()
        {
            var nav = new NavigationService();

            #region Employee Pages

            nav.Configure(MainPageKey, typeof(MainPage));
            nav.Configure(EmployeeMainPageKey, typeof(Pages.EmployeeMainPage));
            nav.Configure(FindClientPageKey, typeof(Pages.FindClientPage));
            nav.Configure(AddNewClientPageKey, typeof(Pages.AddNewClientPage));
            nav.Configure(ClientsInfoPageKey, typeof(Pages.ClientsInfoPage));

            #endregion Employee Pages

            #region Manager Pages

            nav.Configure(ManagerMainPageKey, typeof(Pages.ManagerMainPage));
            nav.Configure(AddNewPackagePageKey, typeof(Pages.AddNewPackagePage));
            nav.Configure(MostAnnoyingCustomerPageKey, typeof(Pages.MostAnnoyingCustomerPage));
            nav.Configure(MostConnectedClientPageKey, typeof(Pages.MostConnectedClientPage));
            nav.Configure(MostProfitableClientPageKey, typeof(Pages.MostProfitableClientPage));

            #endregion Manager Pages

            SimpleIoc.Default.Register<INavigationService>(() => nav);
        }

        #region Setting ViewModels

        public MainViewModel MainView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        #region Employee Views

        public ClientsInfoViewModel ClientsInfoViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ClientsInfoViewModel>();
            }
        }

        public EmployeeMainViewModel EmployeeMainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EmployeeMainViewModel>();
            }
        }

        public FindClientViewModel FindClientViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FindClientViewModel>();
            }
        }

        public AddNewClientViewModel AddNewClientViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddNewClientViewModel>();
            }
        }

        #endregion Employee Views

        #region Manager Views

        public ManagerMainViewModel ManagerMainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ManagerMainViewModel>();
            }
        }

        public AddNewPackageViewModel AddNewPackageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddNewPackageViewModel>();
            }
        }

        public MostAnnoyingCustomerViewModel MostAnnoyingCustomerViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MostAnnoyingCustomerViewModel>();
            }
        }

        public MostConnectedClientViewModel MostConnectedClientViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MostConnectedClientViewModel>();
            }
        }

        public MostProfitableClientViewModel MostProfitableClientViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MostProfitableClientViewModel>();
            }
        }

        #endregion Manager Views

        public T Resolve<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }

        #endregion Setting ViewModels
    }
}