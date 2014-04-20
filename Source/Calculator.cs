using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Source
{
    public class Calculator
    {
        NumbersInformationParser numbersParser = new NumbersInformationParser();
        IValidator validator;

        public Calculator(IValidator validator)
        {
            this.validator = validator;
        }

        public int Add(string numbers)
        {
            var information = ParseInformation(numbers);
            ValidateFormat(information.Delimiters, information.Numbers, this.validator);
            return PerformOperation(information);
        }

        private INumbersInformation ParseInformation(string numbers)
        {
            return this.numbersParser.Parse(numbers);
        }

        private static int PerformOperation(INumbersInformation information)
        {
            try
            {
                return string.IsNullOrEmpty(information.Numbers) ? 0 : SplitBySeparatorsAndSum(information.Delimiters, information.Numbers);
            }
            catch  (FormatException fe)
            {
                throw new CalculatorFormatException(fe.Message);
            }
        }

        private static int SplitBySeparatorsAndSum(List<char> separators, string numbers)
        {
            return numbers.Split(separators.ToArray()).Sum(x => int.Parse(x));
        }

        private static void ValidateFormat(List<char> delimiters, string numbers, IValidator validator)
        {
            if (!validator.Validate(numbers, delimiters))
            {
                throw new CalculatorFormatException(validator.LastErrorMessage);
            }            
        }
    }
}
