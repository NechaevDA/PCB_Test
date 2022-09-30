using CommunityToolkit.Mvvm.ComponentModel;
using PCB_Test.Models;
using PCB_Test.UI.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Media;

namespace PCB_Test.UI.ViewModels
{
    internal class QuoteTabViewModel : TabViewModelBase
    {
        public override string Header => "Quote";
        private OrderDetailsDisplayViewModel _orderDetailsDisplayViewModel;
        private GraphicRepresentationViewModel _graphicRepresentationViewModel;

        public GraphicRepresentationViewModel GraphicRepresentationViewModel
        {
            get { return _graphicRepresentationViewModel; }
            set { _graphicRepresentationViewModel = value; }
        }

        public OrderDetailsDisplayViewModel OrderDetailsDisplayViewModel
        {
            get { return _orderDetailsDisplayViewModel; }
            set { SetProperty(ref _orderDetailsDisplayViewModel, value); }
        }

        public OrderViewModel Model { get; private set; }

        public QuoteTabViewModel()
        {
            OrderDetailsDisplayViewModel = new OrderDetailsDisplayViewModel();
        }

        public void SetModel(OrderViewModel model)
        {
            if (Model != null)
                Model.PropertyChanged -= OnModelChanged;

            Model = model;

            if (Model != null)
                Model.PropertyChanged += OnModelChanged;

            IsEnabled = Model != null;
            
            UpdateViews();
        }

        private void OnModelChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateViews();
        }

        private void UpdateViews()
        {
            if (GraphicRepresentationViewModel != null)
                GraphicRepresentationViewModel.Dispose();
            GraphicRepresentationViewModel = new GraphicRepresentationViewModel(Model);

            if (OrderDetailsDisplayViewModel != null)
                OrderDetailsDisplayViewModel.Update(Model.Model);
        }
    }
}
