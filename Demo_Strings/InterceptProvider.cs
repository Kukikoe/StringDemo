using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Strings
{
    class InterceptProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(String format, Object obj, IFormatProvider provider)
        {
            // Display information about method call.
            string formatString = format ?? "<null>";
            Console.WriteLine("Provider: {0}, Object: {1}, Format String: {2}",
                              provider, obj ?? "<null>", formatString);

            if (obj == null) return String.Empty;

            // If this is a byte and the "R" format string, format it with Roman numerals.
            if (obj is Byte && formatString.ToUpper().Equals("R"))
            {
                Byte value = (Byte)obj;
                int remainder;
                int result;
                String returnString = String.Empty;

                // Get the hundreds digit(s)
                result = Math.DivRem(value, 100, out remainder);
                if (result > 0)
                    returnString = new String('C', result);
                value = (Byte)remainder;
                // Get the 50s digit
                result = Math.DivRem(value, 50, out remainder);
                if (result == 1)
                    returnString += "L";
                value = (Byte)remainder;
                // Get the tens digit.
                result = Math.DivRem(value, 10, out remainder);
                if (result > 0)
                    returnString += new String('X', result);
                value = (Byte)remainder;
                // Get the fives digit.
                result = Math.DivRem(value, 5, out remainder);
                if (result > 0)
                    returnString += "V";
                value = (Byte)remainder;
                // Add the ones digit.
                if (remainder > 0)
                    returnString += new String('I', remainder);

                // Check whether we have too many X characters.
                int pos = returnString.IndexOf("XXXX");
                if (pos >= 0)
                {
                    int xPos = returnString.IndexOf("L");
                    if (xPos >= 0 & xPos == pos - 1)
                        returnString = returnString.Replace("LXXXX", "XC");
                    else
                        returnString = returnString.Replace("XXXX", "XL");
                }
                // Check whether we have too many I characters
                pos = returnString.IndexOf("IIII");
                if (pos >= 0)
                    if (returnString.IndexOf("V") >= 0)
                        returnString = returnString.Replace("VIIII", "IX");
                    else
                        returnString = returnString.Replace("IIII", "IV");

                return returnString;
            }

            // Use default for all other formatting.
            if (obj is IFormattable)
                return ((IFormattable)obj).ToString(format, CultureInfo.CurrentCulture);
            else
                return obj.ToString();
        }

    }
}

