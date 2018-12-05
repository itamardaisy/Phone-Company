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
        private const string EmployeeMainPageKey = "EmployeeMainPage";
        private const string FindClientPageKey = "FindClientPage";
        private const string AddNewClientPageKey = "AddNewClientPage";
        private const string ClientsInfoPageKey = "ClientsInfoPage";
        private const string ManagerMainPageKey = "ManagerMainPage";

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
            SimpleIoc.Default.Register<ManagerMainViewModel>();
            SimpleIoc.Default.Register<ClientsInfoViewModel>();
            //Example For Registering Service
            //  SimpleIoc.Default.Register<IService, Service>();

            #endregion ViewModel Register

            SetUpNavigation();
        }

        /// <summary>
        /// Configuring each PageKey for a page
        /// </summary>
        private void SetUpNavigation()
        {
            var nav = new NavigationService();

            nav.Configure(MainPageKey, typeof(MainPage));
            nav.Configure(EmployeeMainPageKey, typeof(Pages.EmployeeMainPage));
            nav.Configure(FindClientPageKey, typeof(Pages.FindClientPage));
            nav.Configure(AddNewClientPageKey, typeof(Pages.AddNewClientPage));
            nav.Configure(ClientsInfoPageKey, typeof(Pages.ClientsInfoPage));
            nav.Configure(ManagerMainPageKey, typeof(Pages.ManagerMainPage));
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

        public ManagerMainViewModel ManagerMainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ManagerMainViewModel>();
            }
        }

        public T Resolve<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }

        #endregion Setting ViewModels
    }
}