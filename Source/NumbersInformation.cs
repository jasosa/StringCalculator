using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Source
{
    public class NumbersInformation : INumbersInformation
    {
        char delimiter;
        string numbers;

        public NumbersInformation(char delimiter, string numbers)
        {
            this.delimiter = delimiter;
            this.numbers = numbers;
        }

        public string Numbers
        {
            get { return numbers; }
        }

        public List<char> Delimiters
        {
            get
            {
                return new List<char> { delimiter, '\n' };
            }
        }
    }
}

