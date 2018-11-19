using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace UI.Employee.ViewModel
{
    internal class ViewModelLocator
    {
        #region PageKey for navigation Service

        public const string MainPageKey = "MainView";
        public const string EmployeeMainPageKey = "EmployeeMainPage";

        #endregion PageKey for navigation Service

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #region Navigation Key Configure

            //Configuring each PageKey for a page

            var nav = new NavigationService();
            nav.Configure(EmployeeMainPageKey, typeof(Pages.EmployeeMainPage));
            nav.Configure(MainPageKey, typeof(MainPage));

            #endregion Navigation Key Configure

            #region ViewModel Register

            //Registering all the Views in ViewLocator

            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<EmployeeMainViewModel>();

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

        public EmployeeMainViewModel EmployeeMainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EmployeeMainViewModel>();
            }
        }

        public T Resolve<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }
    }
}