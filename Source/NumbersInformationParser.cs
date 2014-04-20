using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class NumbersInformationParser
    {
        private static string changeDelimiterCharacter = "//";
        private static int seekLength = 2;
        private static char defaultDelimiter = ',';        

        internal INumbersInformation Parse(string numbers)
        {
            var delimiter = GetDelimiter(numbers);
            var formattedNumbers = RemoveDelimiterInformation(numbers);
            return new NumbersInformation(delimiter, formattedNumbers);
        }

        private string RemoveDelimiterInformation(string numbers)
        {
            if (numbers.StartsWith(changeDelimiterCharacter))
            {
                numbers = numbers.Remove(0, numbers.IndexOf("\n") + 1);
            }

            return numbers;
        }

        private char GetDelimiter(string numbers)
        {
            if (numbers.StartsWith(changeDelimiterCharacter))
            {
                var separator = numbers.Substring(seekLength, 1);
                return char.Parse(separator);
            }
            else
            {
                return defaultDelimiter;
            }
        }
    }
}
