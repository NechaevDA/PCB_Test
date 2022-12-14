using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace PCB_Test.UI.Helpers
{
    public class RgbConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                var r = System.Convert.ToByte(values[0]);
                var g = System.Convert.ToByte(values[1]);
                var b = System.Convert.ToByte(values[2]);

                return Color.FromRgb(r, g, b);
            } catch
            {
                return Colors.Transparent;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
