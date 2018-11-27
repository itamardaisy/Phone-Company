using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Employee.Helper
{
    internal interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}