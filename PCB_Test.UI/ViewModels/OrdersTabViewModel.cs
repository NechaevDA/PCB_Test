using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PCB_Test.Services.Interfaces;
using PCB_Test.UI.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace PCB_Test.UI.ViewModels
{
    internal class OrdersTabViewModel : TabViewModelBase
    {
        public override string Header => "Orders";
        private OrderViewModel _selectedOrder;
        private readonly IOrderFactory _orderFactory;

        public OrderViewModel SelectedOrder
        {
            get { return _selectedOrder; }
            set { SetProperty(ref _selectedOrder, value); }
        }

        public ObservableCollection<OrderViewModel> Orders { get; }
        public ICommand CheckoutCommand { get; }
        public ICommand CreateOrderCommand { get; }

        public OrdersTabViewModel(IOrderFactory orderFactory)
        {
            // This tab is always enabled, as it manages orders
            IsEnabled = true;
            Orders = new ObservableCollection<OrderViewModel>();

            CheckoutCommand = new RelayCommand(Checkout);
            CreateOrderCommand = new RelayCommand(CreateOrder);
            _orderFactory = orderFactory;
        }

        private void CreateOrder()
        {
            var orderNamePlaceholder = $"Order {Orders.Count + 1}";
            var order = _orderFactory.BuildDefaultOrder(orderNamePlaceholder);

            Orders.Add(new OrderViewModel(order));
        }

        private void Checkout()
        {
            MessageBox.Show($"Payment information and location was found on this device.\nYour order will be delivered in 7 days.\n{SelectedOrder}", "Checkout");
        }
    }
}
