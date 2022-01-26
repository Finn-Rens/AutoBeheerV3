using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AutoBeheerV3.Views
{
    class DecimalValidationRule : ValidationRule
    {
        private const string InvalidInput = "Voer een prijs in ajb";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (decimal.TryParse(value.ToString(), out decimal resultValue))
            {
                return new ValidationResult(true, null);
            }

            return new ValidationResult(false, InvalidInput);
        }
    }
}
