using CommunityToolkit.Mvvm.ComponentModel;
using PCB_Test.Models;
using PCB_Test.UI.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PCB_Test.UI.ViewModels
{
    internal class QuoteTabViewModel : TabViewModelBase
    {
        public override string Header => "Quote";
        private OrderDetailsDisplayViewModel _orderDetailsDisplayViewModel;

        public OrderDetailsDisplayViewModel OrderDetailsDisplayViewModel
        {
            get { return _orderDetailsDisplayViewModel; }
            set { SetProperty(ref _orderDetailsDisplayViewModel, value); }
        }

        public OrderViewModel Model { get; private set; }

        public void SetModel(OrderViewModel model)
        {
            if (Model != null)
                Model.PropertyChanged -= OnModelChanged;

            Model = model;

            if (Model != null)
                Model.PropertyChanged += OnModelChanged;

            IsEnabled = Model != null;
            OrderDetailsDisplayViewModel = new OrderDetailsDisplayViewModel(Model.Model);
        }

        private void OnModelChanged(object sender, PropertyChangedEventArgs e)
        {
            OrderDetailsDisplayViewModel = new OrderDetailsDisplayViewModel(Model.Model);
        }
    }
}
