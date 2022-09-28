using System;
using System.Collections.Generic;
using System.Text;

namespace PCB_Test.UI.Helpers.Validation
{
    class LimitedNumberRule : IValidationRule 
    {
        public string ErrorMessage => $"Value not in range [{MinValue}..{MaxValue}]";

        public int MaxValue { get; }
        public int MinValue { get; }

        public LimitedNumberRule(int minValue, int maxValue)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }

        public bool Validate(string input) => int.TryParse(input, out var number) && number >= MinValue && number <= MaxValue;
    }
}
