using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace PCB_Test.UI.Helpers.Validation
{
    class IntValidationRule : ValidationRule
    {
        public int Min { get; set; } = int.MinValue;
        public int Max { get; set; } = int.MaxValue;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int parsedValue;

            var valueString = (string)value;

            if (string.IsNullOrWhiteSpace(valueString))
                return new ValidationResult(false, "Field is required");

            try
            {
                parsedValue = int.Parse(valueString);
            }
            catch
            {
                return new ValidationResult(false, "Field contains invalid characters");
            }

            if (parsedValue < Min || parsedValue > Max)
                return new ValidationResult(false, $"Value should be in range [{Min}..{Max}]");

            return ValidationResult.ValidResult;
        }
    }
}
