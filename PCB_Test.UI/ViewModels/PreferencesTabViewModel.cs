using CommunityToolkit.Mvvm.ComponentModel;
using PCB_Test.DataProvider.Interfaces;
using PCB_Test.Models;
using PCB_Test.UI.Helpers.Validation;
using PCB_Test.UI.ViewModels.Interfaces;
using PCB_Test.UI.ViewModels.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PCB_Test.UI.ViewModels
{
    internal class PreferencesTabViewModel : TabViewModelBase
    {
        public override string Header => "Preferences";

        public OrderViewModel Model { get; private set; }
        public ObservableCollection<MaterialViewModel> AvailableMaterials { get; }
        public ObservableCollection<MaskColorViewModel> AvailableMaskColors { get; }
        public ObservableCollection<ComponentSetViewModel> AvailableComponentSets { get; }
        public ObservableCollection<IValidationRule> OrderNameValidationRules { get; }
        public ObservableCollection<IValidationRule> OrderDimensionsValidationRules { get; }
        public ObservableCollection<IValidationRule> OrderQuantityValidationRules { get; }
        public ObservableCollection<IValidationRule> OrderLayersValidationRules { get; }


        private readonly IDataProvider _dataProvider;
        private bool _suppressPropertyChanged;

        public PreferencesTabViewModel(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;

            var materialViewModels = _dataProvider.GetAllMaterials().Select(material => new MaterialViewModel(material));
            AvailableMaterials = new ObservableCollection<MaterialViewModel>(materialViewModels);

            var maskColorViewModels = _dataProvider.GetAllMaskColors().Select(maskColor => new MaskColorViewModel(maskColor));
            AvailableMaskColors = new ObservableCollection<MaskColorViewModel>(maskColorViewModels);

            var componentSetViewModels = _dataProvider.GetComponentSets().Select(componentSet => new ComponentSetViewModel(componentSet));
            AvailableComponentSets = new ObservableCollection<ComponentSetViewModel>(componentSetViewModels);

            OrderNameValidationRules = new ObservableCollection<IValidationRule>(ValidationRulesBuilder.Init()
                                                                                                       .Required()
                                                                                                       .Build());

            OrderDimensionsValidationRules = new ObservableCollection<IValidationRule>(ValidationRulesBuilder.Init()
                                                                                                             .Required()
                                                                                                             .Limited(0d, 100d)
                                                                                                             .Build());

            OrderQuantityValidationRules = new ObservableCollection<IValidationRule>(ValidationRulesBuilder.Init()
                                                                                                           .Required()
                                                                                                           .Limited(1, int.MaxValue)
                                                                                                           .Build());

            OrderLayersValidationRules = new ObservableCollection<IValidationRule>(ValidationRulesBuilder.Init()
                                                                                                         .Required()
                                                                                                         .Limited(1, 10)
                                                                                                         .Build());
        }

        public void SetModel(OrderViewModel model)
        {
            ExecuteWithoutNotification(() =>
            {
                Model = model;
                IsEnabled = Model != null;
            });
        }

        private void ExecuteWithoutNotification(Action action)
        {
            _suppressPropertyChanged = true;

            action();

            _suppressPropertyChanged = false;
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (_suppressPropertyChanged)
                return;

            
        }
    }
}
