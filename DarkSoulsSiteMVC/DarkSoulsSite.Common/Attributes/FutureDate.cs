using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSoulsSite.Common.Attributes
{
    class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime eventDate;
            bool isValid = DateTime.TryParseExact(
                 Convert.ToString(value),
                 "d MMM yyyy",
                 CultureInfo.CurrentCulture,
                 DateTimeStyles.None,
                 out eventDate);

            return (isValid && eventDate > DateTime.Now);
        }
    }
}
