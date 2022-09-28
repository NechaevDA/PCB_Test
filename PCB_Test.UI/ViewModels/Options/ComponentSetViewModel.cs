using PCB_Test.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCB_Test.UI.ViewModels.Options
{
    internal class ComponentSetViewModel
    {
        public string DisplayName => Model.Name;
        public ComponentSet Model { get; }

        public ComponentSetViewModel(ComponentSet model)
        {
            Model = model;
        }
    }
}
