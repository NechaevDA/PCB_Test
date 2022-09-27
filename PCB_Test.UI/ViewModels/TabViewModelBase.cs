using CommunityToolkit.Mvvm.ComponentModel;
using PCB_Test.UI.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCB_Test.UI.ViewModels
{
    internal abstract class TabViewModelBase : ObservableObject, ITabViewModel
    {
        public abstract string Header { get; }

        private bool _isEnabled;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }
    }
}
