using CommunityToolkit.Mvvm.ComponentModel;
using PCB_Test.DataProvider.Interfaces;
using PCB_Test.Services.Implementations;
using PCB_Test.Services.Interfaces;
using PCB_Test.UI.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PCB_Test.UI.ViewModels
{
    internal class MainWindowViewModel
    {
        public ObservableCollection<ITabViewModel> TabViewModels { get; }

        private PreferencesTabViewModel _preferencesTabViewModel;
        private OrdersTabViewModel _ordersTabViewModel;
        private QuoteTabViewModel _quoteTabViewModel;

        public MainWindowViewModel()
        {
            _ordersTabViewModel = new OrdersTabViewModel(App.GetService<IOrderFactory>());
            _quoteTabViewModel = new QuoteTabViewModel();
            _preferencesTabViewModel = new PreferencesTabViewModel(App.GetService<IDataProvider>());

            TabViewModels = new ObservableCollection<ITabViewModel>();
            TabViewModels.Add(_ordersTabViewModel);
            TabViewModels.Add(_preferencesTabViewModel);
            TabViewModels.Add(_quoteTabViewModel);

            _ordersTabViewModel.SelectedOrderChanged += OnSelectedOrderChanged;
        }

        private void OnSelectedOrderChanged(object sender, OrderViewModel e)
        {
            _preferencesTabViewModel.SetModel(e);
            _quoteTabViewModel.SetModel(e);
        }
    }
}
