using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class CalculatorFormatException : Exception
    {
        public CalculatorFormatException(string message)
            : base(message)
        {
        }
    }
}
