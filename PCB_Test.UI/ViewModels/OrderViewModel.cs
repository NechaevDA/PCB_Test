using CommunityToolkit.Mvvm.ComponentModel;
using PCB_Test.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PCB_Test.UI.ViewModels
{
    public class OrderViewModel : ObservableObject
    {
        private double _totalCost;
        private double _totalTime;
        private double _height;
        private double _width;
        private int _layersCount;
        private int _quantity;
        private Material _material;
        private MaskColor _maskColor;
        private string _displayName;
        private ComponentSet _componentSet;

        public ComponentSet ComponentSet
        {
            get { return _componentSet; }
            set {
                SetProperty(ref _componentSet, value);
                Model.ComponentSet = value;
            }
        }

        public string Name
        {
            get { return _displayName; }
            set
            {
                SetProperty(ref _displayName, value);
                Model.Name = value;
            }
        }

        public MaskColor MaskColor
        {
            get { return _maskColor; }
            set
            {
                SetProperty(ref _maskColor, value);
                Model.MaskColor = value;
            }
        }

        public Material Material
        {
            get { return _material; }
            set
            {
                SetProperty(ref _material, value);
                Model.Material = value;
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                SetProperty(ref _quantity, value);
                Model.Quantity = value;
            }
        }

        public int LayersCount
        {
            get { return _layersCount; }
            set
            {
                SetProperty(ref _layersCount, value);
                Model.LayerCount = value;
            }
        }

        public double Width
        {
            get { return _width; }
            set
            {
                SetProperty(ref _width, value);
                Model.Width = value;
            }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                SetProperty(ref _height, value);
                Model.Height = value;
            }
        }

        public double TotalTime
        {
            get { return _totalTime; }
            set { SetProperty(ref _totalTime, value); }
        }

        public double TotalCost
        {
            get { return _totalCost; }
            set { SetProperty(ref _totalCost, value); }
        }

        public Order Model { get; }
        private bool _initFlag;
        public OrderViewModel(Order model)
        {
            Model = model;

            _initFlag = true;
            Name = Model.Name;
            Height = Model.Height;
            Width = Model.Width;
            Quantity = Model.Quantity;
            LayersCount = Model.LayerCount;
            Material = Model.Material;
            MaskColor = Model.MaskColor;
            ComponentSet = Model.ComponentSet;

            _initFlag = false;
            Refresh();
        }

        public void Refresh()
        {
            TotalCost = ComponentSet.Components.Sum(x => x.Cost) + Height * Width * Material.Cost;
            TotalTime = ComponentSet.Components.Sum(x => x.TimeToInstall) + Material.TimeCost * (2 * (Height + Width));
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (_initFlag)
                return;

            if (e.PropertyName != nameof(TotalCost) &&
                e.PropertyName != nameof(TotalTime))
                Refresh();
        }
    }
}
