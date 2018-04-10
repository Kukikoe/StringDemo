using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Strings
{
    public class CustomerFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!this.Equals(formatProvider))
            {
                return null;
            }
            else
            {
                if (String.IsNullOrEmpty(format))
                    format = "G";

                string customerString = arg.ToString();
                if (customerString.Length < 8)
                    customerString = customerString.PadLeft(8, '0');

                format = format.ToUpper();
                switch (format)
                {
                    case "G":
                        return customerString.Substring(0, 1) + "-" +
                                              customerString.Substring(1, 5) + "-" +
                                              customerString.Substring(6);
                    case "S":
                        return customerString.Substring(0, 1) + "/" +
                                              customerString.Substring(1, 5) + "/" +
                                              customerString.Substring(6);
                    case "P":
                        return customerString.Substring(0, 1) + "." +
                                              customerString.Substring(1, 5) + "." +
                                              customerString.Substring(6);
                    default:
                        throw new FormatException(
                                  String.Format("The '{0}' format specifier is not supported.", format));
                }
            }
        }
    }
}
