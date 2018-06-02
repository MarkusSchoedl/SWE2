using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PicDB
{
    class BoughtOnValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value != null)
            {
                DateTime boughtOn = DateTime.Today;
                try
                {
                    boughtOn = Convert.ToDateTime(value);
                }
                catch
                {
                    return new ValidationResult(false, "Not a valid date");
                }

                if (boughtOn <= DateTime.Today)
                    return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "You cant predict if you buy a camera!");
        }
    }
}
