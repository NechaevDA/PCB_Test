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
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PCB_Test.UI.ViewModels
{
    internal class PreferencesTabViewModel : TabViewModelBase
    {
        public override string Header => "Preferences";

        private MaterialViewModel _selectedMaterial;
        private ComponentSetViewModel _selectedComponentSet;
        private MaskColorViewModel _selectedMaskColor;

        public MaskColorViewModel SelectedMaskColor
        {
            get { return _selectedMaskColor; }
            set { SetProperty(ref _selectedMaskColor, value); }
        }

        public ComponentSetViewModel SelectedComponentSet
        {
            get { return _selectedComponentSet; }
            set { SetProperty(ref _selectedComponentSet, value); }
        }

        public MaterialViewModel SelectedMaterial
        {
            get { return _selectedMaterial; }
            set { SetProperty(ref _selectedMaterial, value); }
        }

        public OrderViewModel Model { get; private set; }
        public ObservableCollection<MaterialViewModel> AvailableMaterials { get; }
        public ObservableCollection<MaskColorViewModel> AvailableMaskColors { get; }
        public ObservableCollection<ComponentSetViewModel> AvailableComponentSets { get; }


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
        }

        public void SetModel(OrderViewModel model)
        {
            ExecuteWithoutNotification(() =>
            {
                Model = model;
                SelectedMaskColor = AvailableMaskColors.First(x => x.Model.Id == Model.MaskColor.Id);
                SelectedComponentSet = AvailableComponentSets.First(x => x.Model.Id == Model.ComponentSet.Id);
                SelectedMaterial = AvailableMaterials.First(x => x.Model.Id == Model.Material.Id);
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

            if (e.PropertyName == nameof(SelectedMaterial))
                Model.Material = SelectedMaterial.Model;

            if (e.PropertyName == nameof(SelectedComponentSet))
                Model.ComponentSet = SelectedComponentSet.Model;

            if (e.PropertyName == nameof(SelectedMaskColor))
                Model.MaskColor = SelectedMaskColor.Model;
        }
    }
}
