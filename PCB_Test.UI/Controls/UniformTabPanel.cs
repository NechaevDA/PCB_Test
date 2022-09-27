using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace PCB_Test.UI.Controls
{
    internal class UniformTabPanel : UniformGrid
    {
        public UniformTabPanel()
        {
            IsItemsHost = true;
            Rows = 1;
            HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            var totalMaxWidth = Children.OfType<TabItem>().Sum(tab => tab.MaxWidth);
            if (!double.IsInfinity(totalMaxWidth))
                HorizontalAlignment = constraint.Width > totalMaxWidth
                    ? HorizontalAlignment.Left
                    : HorizontalAlignment.Stretch;

            return base.MeasureOverride(constraint);
        }
    }
}
