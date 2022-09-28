using System;
using System.Collections.Generic;
using System.Text;

namespace PCB_Test.UI.Helpers.Validation
{
    public interface IValidationRule
    {
        string ErrorMessage { get; }
        bool Validate(string input);
    }
}
