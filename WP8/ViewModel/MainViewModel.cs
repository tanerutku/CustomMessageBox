using CommonComponents.Dialog;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP8.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private IDialogService _dialogService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

        }

    }
}
