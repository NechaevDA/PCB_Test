using PCB_Test.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCB_Test.UI.ViewModels.Options
{
    internal class MaskColorViewModel
    {
        public string DisplayName => Model.Name;
        public byte ColorR => Model.R;
        public byte ColorG => Model.G;
        public byte ColorB => Model.B;

        public MaskColor Model { get; }

        public MaskColorViewModel(MaskColor model)
        {
            Model = model;
        }
    }
}
