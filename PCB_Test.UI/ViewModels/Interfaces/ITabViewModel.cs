using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PCB_Test.UI.ViewModels.Interfaces
{
    interface ITabViewModel : INotifyPropertyChanged
    {
        string Header { get; }
        bool IsEnabled { get; }
    }
}
