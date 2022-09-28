using PCB_Test.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCB_Test.UI.ViewModels.Options
{
    internal class MaterialViewModel
    {
        public string DisplayName => Model.Name;
        public double Cost => Model.Cost;
        public double TimeCost => Model.TimeCost;
        public Material Model { get; }

        public MaterialViewModel(Material model)
        {
            Model = model;
        }
    }
}
