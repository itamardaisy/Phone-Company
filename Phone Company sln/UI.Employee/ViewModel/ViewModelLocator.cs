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

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #region Navigation Key Configure

            //Configuring each PageKey for a page

            var nav = new NavigationService();
            nav.Configure(MainPageKey, typeof(MainPage)/*new Uri("../MainPage.xaml", UriKind.Relative)*/);
            nav.Configure(EmployeeMainPageKey, typeof(Pages.EmployeeMainPage) /*new Uri("../Pages/EmployeeMainPage.xaml", UriKind.Relative));*/);
            nav.Configure(FindClientPageKey, typeof(Pages.FindClientPage) /*new Uri("../Pages/FindClientPage.xaml", UriKind.Relative));*/  );
            nav.Configure(AddNewClientPageKey, typeof(Pages.AddNewClientPage) /*new Uri("../Pages/AddNewClientPage.xaml", UriKind.Relative));*/);
            nav.Configure(ClientsInfoPageKey, typeof(Pages.ClientsInfoPage) /*new Uri("../Pages/ClientsInfoPage.xaml", UriKind.Relative));*/ );

            #endregion Navigation Key Configure

            #region ViewModel Register

            //Registering all the Views in ViewLocator

            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<EmployeeMainViewModel>();
            SimpleIoc.Default.Register<FindClientViewModel>();
            SimpleIoc.Default.Register<AddNewClientViewModel>();
            SimpleIoc.Default.Register<ClientsInfoViewModel>();

            //Example For Registering Service
            //  SimpleIoc.Default.Register<IService, Service>();

            #endregion ViewModel Register
        }

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
    }
}