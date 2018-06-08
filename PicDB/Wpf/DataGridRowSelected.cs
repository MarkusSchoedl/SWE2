using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PicDB
{
    public class DataGridRowSelected : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value != null)
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, Message);
        }

        public String Message { get; set; }
    }
}
