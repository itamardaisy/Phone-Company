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

        public const string MainPageKey = "MainView";
        public const string EmployeeMainPageKey = "EmployeeMainPage";
        public const string FindClientPageKey = "FindClientPage";
        public const string AddNewClientPageKey = "AddNewClientPage";
        public const string ClientsInfoPageKey = "ClientsInfoPage";

        #endregion PageKey for navigation Service

        /// <summary>
        /// Registering all the Views in ViewLocator In The Constructor
        /// </summary>
        public ViewModelLocator()
        {
            #region ViewModel Register

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<EmployeeMainViewModel>();
            SimpleIoc.Default.Register<FindClientViewModel>();
            SimpleIoc.Default.Register<AddNewClientViewModel>();
            SimpleIoc.Default.Register(() => new ClientsInfoViewModel());
            //Example For Registering Service
            //  SimpleIoc.Default.Register<IService, Service>();

            #endregion ViewModel Register

            SetUpNavigation();
        }

        /// <summary>
        /// Configuring each PageKey for a page
        /// </summary>
        private static void SetUpNavigation()
        {
            var nav = new FrameNavigationService();

            nav.Configure(MainPageKey, new Uri("../MainPage.xaml", UriKind.Relative));
            nav.Configure(EmployeeMainPageKey, new Uri("../Pages/EmployeePage.xaml", UriKind.Relative));
            nav.Configure(FindClientPageKey, new Uri("../Pages/FindClientPage.xaml", UriKind.Relative));
            nav.Configure(AddNewClientPageKey, new Uri("../Pages/AddNewClientPage.xaml", UriKind.Relative));
            nav.Configure(ClientsInfoPageKey, new Uri("../Pages/ClientsInfoPage.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<IFrameNavigationService>(() => nav);
        }

        #region Setting ViewModels

        public MainViewModel MainView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

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

        public T Resolve<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }

        #endregion Setting ViewModels
    }
}