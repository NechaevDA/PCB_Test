using CommunityToolkit.Mvvm.ComponentModel;
using PCB_Test.Models;
using PCB_Test.UI.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PCB_Test.UI.ViewModels
{
    internal class PreferencesTabViewModel : TabViewModelBase
    {
        public override string Header => "Preferences";

        public Order Model { get; private set; }

        public void SetModel(Order model)
        {
            Model = model;
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.PropertyName == nameof(Model))
            {
                IsEnabled = Model != null;
            }
        }
    }
}
