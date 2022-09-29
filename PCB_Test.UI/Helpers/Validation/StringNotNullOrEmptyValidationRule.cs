using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace PCB_Test.UI.Helpers.Validation
{
    class StringNotNullOrEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace((string)value))
                return new ValidationResult(false, "Field is required");

            return ValidationResult.ValidResult;
        }
    }
}
