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
        public const string MainPageKey = "MainView";

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #region Navigation Key Configure

            var nav = new NavigationService();
            // nav.Configure(ClientLoginPageKey, typeof(Page.ClientLoginPage));

            #endregion Navigation Key Configure

            #region ViewModel Register

            SimpleIoc.Default.Register<INavigationService>(() => nav);
            // SimpleIoc.Default.Register<MainViewModel>();

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

        public T Resolve<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }
    }
}