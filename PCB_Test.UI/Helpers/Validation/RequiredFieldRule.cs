using System;
using System.Collections.Generic;
using System.Text;

namespace PCB_Test.UI.Helpers.Validation
{
    class RequiredFieldRule : IValidationRule
    {
        public string ErrorMessage => "This field is required";

        public bool Validate(string input) => !string.IsNullOrWhiteSpace(input);
    }
}
