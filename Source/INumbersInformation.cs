using System;
using System.Collections.Generic;
namespace Source
{
    interface INumbersInformation
    {
        List<char> Delimiters { get; }
        string Numbers { get; }
    }
}
