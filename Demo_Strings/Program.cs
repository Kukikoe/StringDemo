using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Strings
{
    class Program
    {
            static void Demo1()
            {
                Decimal pricePerOunce = 17.36m;
                String s = String.Format("The current price is {0} per ounce.", pricePerOunce);
                Console.WriteLine(s);  // The current price is 17.36 per ounce.

                String s2 = String.Format("The current price is {0:C2} per ounce.", pricePerOunce);
                Console.WriteLine(s2);  // The current price is 17.36 per ounce.

                string s3 = String.Format("At {0}, the temperature is {1}°C.", DateTime.Now, 20.4);
                Console.WriteLine(s3);
                // Output similar to: 'At 4/10/2015 9:29:41 AM, the temperature is 20.4°C.'

                string s4 = String.Format("It is now {0:d} at {0:t}", DateTime.Now);
                Console.WriteLine(s4);
                // Output similar to: 'It is now 4/10/2015 at 10:04 AM
            }

            static void Demo2()
            {
                int[] years = { 2013, 2014, 2015 };
                int[] population = { 1025632, 1105967, 1148203 };
                String s = String.Format("{0,6} {1,15}\n\n", "Year", "Population");
                for (int index = 0; index < years.Length; index++)
                    s += String.Format("{0,6} {1,15:N0}\n", years[index], population[index]);
                // Result:
                //      Year      Population
                //
                //      2013       1,025,632
                //      2014       1,105,967
                //      2015       1,148,203
                Console.WriteLine(s);

                String s2 = String.Format("{0,-10} {1,-10}\n\n", "Year", "Population");
                for (int index = 0; index < years.Length; index++)
                    s2 += String.Format("{0,-10} {1,-10:N0}\n", years[index], population[index]);
                Console.WriteLine(s2);
            }

            static void Demo3()
            {
                // Create array of 5-tuples with population data for three U.S. cities, 1940-1950.
                Tuple<string, DateTime, int, DateTime, int>[] cities =
                    { Tuple.Create("Los Angeles", new DateTime(1940, 1, 1), 1504277,
                         new DateTime(1950, 1, 1), 1970358),
            Tuple.Create("New York", new DateTime(1940, 1, 1), 7454995,
                         new DateTime(1950, 1, 1), 7891957),
            Tuple.Create("Chicago", new DateTime(1940, 1, 1), 3396808,
                         new DateTime(1950, 1, 1), 3620962),
            Tuple.Create("Detroit", new DateTime(1940, 1, 1), 1623452,
                         new DateTime(1950, 1, 1), 1849568) };

                // Display header
                string header = String.Format("{0,-12}{1,8}{2,12}{1,8}{2,12}{3,14}\n",
                                              "City", "Year", "Population", "Change (%)");
                Console.WriteLine(header);
                string output;
                foreach (var city in cities)
                {
                    output = String.Format("{0,-12}{1,8:yyyy}{2,12:N0}{3,8:yyyy}{4,12:N0}{5,14:P1}",
                                           city.Item1, city.Item2, city.Item3, city.Item4, city.Item5,
                                           (city.Item5 - city.Item3) / (double)city.Item3);
                    Console.WriteLine(output);
                }
            }

            static void Demo4()
            {
                short[] values = { Int16.MinValue, -27, 0, 1042, Int16.MaxValue };
                Console.WriteLine("{0,10}  {1,10}\n", "Decimal", "Hex");
                foreach (short value in values)
                {
                    string formatString = String.Format("{0,10:G}: {0,10:X}", value);
                    Console.WriteLine(formatString);
                }
            }

            static void Demo5()
            {
                DateTime birthdate = new DateTime(1993, 7, 28);
                DateTime[] dates = { new DateTime(1993, 8, 16),
                           new DateTime(1994, 7, 28),
                           new DateTime(2000, 10, 16),
                           new DateTime(2003, 7, 27),
                           new DateTime(2007, 5, 27) };

                foreach (DateTime dateValue in dates)
                {
                    TimeSpan interval = dateValue - birthdate;
                    // Get the approximate number of years, without accounting for leap years.
                    int years = ((int)interval.TotalDays) / 365;
                    // See if adding the number of years exceeds dateValue.
                    string output;
                    if (birthdate.AddYears(years) <= dateValue)
                    {
                        output = String.Format("You are now {0} years old.", years);
                        Console.WriteLine(output);
                    }
                    else
                    {
                        output = String.Format("You are now {0} years old.", years - 1);
                        Console.WriteLine(output);
                    }
                }
            }

            static void Demo6()
            {
                Dictionary<DateTime, Double> temperatureInfo = new Dictionary<DateTime, Double>();
                temperatureInfo.Add(new DateTime(2010, 6, 1, 14, 0, 0), 87.46);
                temperatureInfo.Add(new DateTime(2010, 12, 1, 10, 0, 0), 36.81);

                Console.WriteLine("Temperature Information:\n");
                string output;
                foreach (var item in temperatureInfo)
                {
                    output = String.Format("Temperature at {0,8:t} on {0,9:d}: {1,5:N1}°F",
                                           item.Key, item.Value);
                    Console.WriteLine(output);
                }
            }

            static void Demo7()
            {
                string formatString = "    {0,10} ({0,8:X8})\n" +
                                      "And {1,10} ({1,8:X8})\n" +
                                      "  = {2,10} ({2,8:X8})";
                int value1 = 16932;
                int value2 = 15421;
                string result = String.Format(formatString,
                                              value1, value2, value1 & value2);
                Console.WriteLine(result);
            }

            static void Demo8()
            {
                DateTime date1 = new DateTime(2009, 7, 1);
                TimeSpan hiTime = new TimeSpan(14, 17, 32);
                decimal hiTemp = 62.1m;
                TimeSpan loTime = new TimeSpan(3, 16, 10);
                decimal loTemp = 54.8m;

                string result1 = String.Format("Temperature on {0:d}:\n{1,11}: {2} degrees (hi)\n{3,11}: {4} degrees (lo)",
                                               date1, hiTime, hiTemp, loTime, loTemp);
                Console.WriteLine(result1);
                Console.WriteLine();

                string result2 = String.Format("Temperature on {0:d}:\n{1,11}: {2} degrees (hi)\n{3,11}: {4} degrees (lo)",
                                               new object[] { date1, hiTime, hiTemp, loTime, loTemp });
                Console.WriteLine(result2);
            }

            static void Demo9()
            {
                string[] cultureNames = { "en-US", "fr-FR", "de-DE", "es-ES" };

                DateTime dateToDisplay = new DateTime(2009, 9, 1, 18, 32, 0);
                double value = 9164.32;

                Console.WriteLine("Culture     Date                                Value\n");
                foreach (string cultureName in cultureNames)
                {
                    CultureInfo culture = new CultureInfo(cultureName);
                    string output = String.Format(culture, "{0,-11} {1,-35:D} {2:N}",
                                                  culture.Name, dateToDisplay, value);
                    Console.WriteLine(output);
                }
            }

            static void Demo10()
            {
                int acctNumber = 79203159;
                Console.WriteLine(String.Format(new CustomerFormatter(), "{0}", acctNumber));
                Console.WriteLine(String.Format(new CustomerFormatter(), "{0:G}", acctNumber));
                Console.WriteLine(String.Format(new CustomerFormatter(), "{0:S}", acctNumber));
                Console.WriteLine(String.Format(new CustomerFormatter(), "{0:P}", acctNumber));
                try
                {
                    Console.WriteLine(String.Format(new CustomerFormatter(), "{0:X}", acctNumber));
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            static void Demo11()
            {
                int n = 10;
                double value = 16.935;
                DateTime day = DateTime.Now;
                InterceptProvider provider = new InterceptProvider();
                Console.WriteLine(String.Format(provider, "{0:N0}: {1:C2} on {2:d}\n", n, value, day));
                Console.WriteLine(String.Format(provider, "{0}: {1:F}\n", "Today: ",
                                                (DayOfWeek)DateTime.Now.DayOfWeek));
                Console.WriteLine(String.Format(provider, "{0:X}, {1}, {2}\n",
                                                (Byte)2, (Byte)12, (Byte)199));
                Console.WriteLine(String.Format(provider, "{0:R}, {1:R}, {2:R}\n",
                                                (Byte)2, (Byte)12, (Byte)199));
            }

            static void Demo12()
            {
                object[] values = { 1603, 1794.68235, 15436.14 };
                string result;
                foreach (var value in values)
                {
                    result = String.Format("{0,12:C2}   {0,12:E3}   {0,12:F4}   {0,12:N3}  {1,12:P2}\n",
                                           Convert.ToDouble(value), Convert.ToDouble(value) / 10000);
                    Console.WriteLine(result);
                }

                decimal val = 16309.5436m;
                result = String.Format("{0,12:#.00000} {0,12:0,000.00} {0,12:000.00#}", val);
                Console.WriteLine(result);
            }

            static void Demo13()
            {
                int value = 1326;
                string result = String.Format("{0,10:D6} {0,10:X8}", value);
                Console.WriteLine(result);

                value = 16342;
                result = String.Format("{0,18:00000000} {0,18:00000000.000} {0,18:000,0000,000.0}", value);
                Console.WriteLine(result);

            }

            static void Demo14()
            {
                try
                {
                    Random rnd = new Random();
                    int[] numbers = new int[4];
                    int total = 0;
                    for (int ctr = 0; ctr <= 2; ctr++)
                    {
                        int number = rnd.Next(1001);
                        numbers[ctr] = number;
                        total += number;
                    }
                    numbers[3] = total;
                    Console.WriteLine("{0} + {1} + {2} = {3}", numbers);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            static void Demo15()
            {
                Random rnd = new Random();
                int[] numbers = new int[4];
                int total = 0;
                for (int ctr = 0; ctr <= 2; ctr++)
                {
                    int number = rnd.Next(1001);
                    numbers[ctr] = number;
                    total += number;
                }
                numbers[3] = total;
                object[] values = new object[numbers.Length];
                numbers.CopyTo(values, 0);
                Console.WriteLine("{0} + {1} + {2} = {3}", values);
            }

            static void Main(string[] args)
            {
                //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Console.OutputEncoding = Encoding.UTF8;
                Demo1();
                Console.WriteLine();
                Demo2();
                Console.WriteLine();
                Demo3();
                Console.WriteLine();
                Demo4();
                Console.WriteLine();
                Demo5();
                Console.WriteLine();
                Demo6();
                Console.WriteLine();
                Demo7();
                Console.WriteLine();
                Demo8();
                Console.WriteLine();
                Demo9();
                Console.WriteLine();
                Demo10();
                Console.WriteLine();
                Demo11();
                Console.WriteLine();
                Demo12();
                Console.WriteLine();
                Demo13();
                Console.WriteLine();
                Demo14();
                Console.WriteLine();
                Demo15();
                Console.ReadKey();
            }
        }
    }

