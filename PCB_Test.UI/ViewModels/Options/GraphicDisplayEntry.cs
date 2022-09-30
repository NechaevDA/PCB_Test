using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace PCB_Test.UI.ViewModels.Options
{
    public struct GraphicDisplayEntry
    {
        public string Title { get; set; }
        public double Value { get; set; }
        public SolidColorBrush Color { get; set; }

        public GraphicDisplayEntry(string title, double value, Color color)
        {
            Title = title;
            Value = value;
            Color = new SolidColorBrush(color);
        }
    }
}
