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

        [PreferredConstructor]
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var nav = new NavigationService();

            #region Navigation Key Configure

            //Configuring each PageKey for a page

            nav.Configure(MainPageKey, typeof(MainPage));
            nav.Configure(EmployeeMainPageKey, typeof(Pages.EmployeeMainPage));
            nav.Configure(FindClientPageKey, typeof(Pages.FindClientPage));
            nav.Configure(AddNewClientPageKey, typeof(Pages.AddNewClientPage));
            nav.Configure(ClientsInfoPageKey, typeof(Pages.ClientsInfoPage));

            #endregion Navigation Key Configure

            #region ViewModel Register

            //Registering all the Views in ViewLocator
            try
            {
                // code causing TargetInvocationException
                SimpleIoc.Default.Register<INavigationService>(() => nav);
                SimpleIoc.Default.Register<MainViewModel>();
                SimpleIoc.Default.Register<EmployeeMainViewModel>();
                SimpleIoc.Default.Register<FindClientViewModel>();
                SimpleIoc.Default.Register<AddNewClientViewModel>();
                SimpleIoc.Default.Register<ClientsInfoViewModel>();
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    string err = e.InnerException.Message;
                }
            }

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