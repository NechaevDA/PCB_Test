using System;
using System.Collections.Generic;
using System.Text;

namespace PCB_Test.UI.Helpers.Validation
{
    class LimitedDoubleRule : IValidationRule
    {
        public string ErrorMessage => $"Value not in range [{MinValue}..{MaxValue}]";

        public double MaxValue { get; }
        public double MinValue { get; }

        public LimitedDoubleRule(double minValue, double maxValue)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }

        public bool Validate(string input) => double.TryParse(input, out var number) && number >= MinValue && number <= MaxValue;
    }
}
