using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Employee.Models;

namespace UI.Employee.ViewModel
{
    internal class AddNewPackageViewModel: ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public RelayCommand NavigateCommandToAddNewPackage { get; set; }
        public RelayCommand NavigateCommandToManagerPage { get; private set; }

        public Package NewPackage { get; set; }

        private bool _isMostCallNumbeChecked;
        public bool IsMostCallNumbeChecked
        {
            get { return _isMostCallNumbeChecked; }
            set
            {
                if (_isMostCallNumbeChecked == value) return;

                _isMostCallNumbeChecked = value;             
            }
        }

        private bool _isInsideFamilyCallChecked;
        public bool IsInsideFamilyCallChecked
        {
            get { return _isInsideFamilyCallChecked; }
            set
            {
               if( _isInsideFamilyCallChecked = value)return;

                _isInsideFamilyCallChecked = value;
            }
        }

        private bool _isSelectedNumberChecked;
        public bool IsSelectedNumberChecked
        {
            get { return _isSelectedNumberChecked; }
            set
            {
                if (_isSelectedNumberChecked = value) return;

                _isSelectedNumberChecked = value;
            }
        }

        public string Name { get; set; }


        public AddNewPackageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommandToManagerPage = new RelayCommand(GoBackCommand);
            NavigateCommandToAddNewPackage = new RelayCommand(CommandToAddNewPackage);
        }

        private void CommandToAddNewPackage()
        {
            NewPackage = new Package
            {
                MostCallNumber = _isMostCallNumbeChecked,
                InsideFamilyCall = _isInsideFamilyCallChecked,
                SelectedNumber = _isSelectedNumberChecked,
                
            };


        }
     
        private void GoBackCommand()
        {
            _navigationService.NavigateTo(pageKey: "ManagerMainPage");
        }
    }
}