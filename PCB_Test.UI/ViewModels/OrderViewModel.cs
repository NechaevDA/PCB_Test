using CommunityToolkit.Mvvm.ComponentModel;
using PCB_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCB_Test.UI.ViewModels
{
    public class OrderViewModel : ObservableObject
    {
        private string _displayName;
        private double _totalCost;
        private double _totalTime;

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

        public string DisplayName
        {
            get { return _displayName; }
            set { SetProperty(ref _displayName, value); }
        }

        public Order Model { get; }

        public OrderViewModel(Order model)
        {
            Model = model;
            Refresh();
        }

        public void Refresh()
        {
            DisplayName = Model.Name;
            TotalCost = Model.Components.Sum(x => x.Cost) + Model.Height * Model.Width * Model.Material.Cost;
            TotalTime = Model.Components.Sum(x => x.TimeToInstall) + Model.Material.TimeCost * (2 * (Model.Height + Model.Width));
        }
    }
}
