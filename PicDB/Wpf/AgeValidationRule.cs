using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PicDB
{
    class AgeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value != null)
            {
                DateTime birthDay = DateTime.Today;
                try
                {
                    birthDay = Convert.ToDateTime(value);
                }
                catch
                {
                    return new ValidationResult(false, "Not a valid date");
                }

                birthDay = birthDay.AddYears(12);

                if (birthDay < DateTime.Today)
                    return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "You must be older than 12!");
        }

    }
}
