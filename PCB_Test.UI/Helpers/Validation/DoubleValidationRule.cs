using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace PCB_Test.UI.Helpers.Validation
{
    class DoubleValidationRule : ValidationRule
    {
        public double Min { get; set; } = double.MinValue;
        public double Max { get; set; } = double.MaxValue;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double parsedValue;

            var valueString = (string)value;

            if (string.IsNullOrWhiteSpace(valueString))
                return new ValidationResult(false, "Field is required");

            try
            {
                parsedValue = double.Parse(valueString);
            }
            catch
            {
                return new ValidationResult(false, "Field contains invalid characters");
            }

            if (parsedValue < Min || parsedValue > Max)
                return new ValidationResult(false, $"Value should be in range [{Min:0.0}..{Max:0.0}]");

            return ValidationResult.ValidResult;
        }
    }
}
