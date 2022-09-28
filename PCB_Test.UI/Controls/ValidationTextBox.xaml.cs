using PCB_Test.UI.Helpers.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PCB_Test.UI.Controls
{
    /// <summary>
    /// Interaction logic for ValidationTextBox.xaml
    /// </summary>
    public partial class ValidationTextBox : UserControl
    {
        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }

        public IEnumerable<IValidationRule> ValidationRules
        {
            get { return (IEnumerable<IValidationRule>)GetValue(ValidationRulesProperty); }
            set { SetValue(ValidationRulesProperty, value); }
        }

        public string InvalidMessage
        {
            get { return (string)GetValue(InvalidMessageProperty); }
            set { SetValue(InvalidMessageProperty, value); }
        }

        public string Input
        {
            get { return (string)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Input.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InputProperty =
            DependencyProperty.Register("Input", typeof(string), typeof(ValidationTextBox), new PropertyMetadata(""));

        // Using a DependencyProperty as the backing store for InvalidMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InvalidMessageProperty =
            DependencyProperty.Register("InvalidMessage", typeof(string), typeof(ValidationTextBox), new PropertyMetadata(""));

        // Using a DependencyProperty as the backing store for ValidationRules.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValidationRulesProperty =
            DependencyProperty.Register("ValidationRules", typeof(IEnumerable<IValidationRule>), typeof(ValidationTextBox), new PropertyMetadata(Enumerable.Empty<IValidationRule>()));

        // Using a DependencyProperty as the backing store for IsValid.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsValidProperty =
            DependencyProperty.Register("IsValid", typeof(bool), typeof(ValidationTextBox), new PropertyMetadata(false));

        public ValidationTextBox()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property.Name == nameof(Input))
                Validate();
        }

        private void Validate()
        {
            var failedRules = ValidationRules.Where(rule => !rule.Validate(Input));

            if (failedRules.Any())
            {
                ErrorTextBlock.Text = string.IsNullOrWhiteSpace(InvalidMessage) ?
                                      string.Join('\n', failedRules.Select(x => x.ErrorMessage)) :
                                      InvalidMessage;
                ErrorTextBlock.Visibility = Visibility.Visible;
                IsValid = false;
            }
            else
            {
                ErrorTextBlock.Visibility = Visibility.Collapsed;
                IsValid = true;
            }
        }
    }
}
