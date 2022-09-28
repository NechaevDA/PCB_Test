using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCB_Test.UI.Helpers.Validation
{
    class ValidationRulesBuilder
    {
        public static ValidationRulesBuilder Init()
        {
            return new ValidationRulesBuilder();
        }

        private List<IValidationRule> _rules = new List<IValidationRule>();
        private ValidationRulesBuilder()
        {
        }

        public ValidationRulesBuilder Required()
        {
            if (!_rules.OfType<RequiredFieldRule>().Any())
                _rules.Add(new RequiredFieldRule());

            return this;
        }

        public ValidationRulesBuilder Limited(int minValue, int maxValue)
        {
            _rules.Add(new LimitedNumberRule(minValue, maxValue));

            return this;
        }

        public ValidationRulesBuilder Limited(double minValue, double maxValue)
        {
            _rules.Add(new LimitedDoubleRule(minValue, maxValue));

            return this;
        }

        public List<IValidationRule> Build()
        {
            return _rules;
        }
    }
}
