using System;
namespace Source
{
    public interface IValidator
    {
        string LastErrorMessage { get; set; }
        bool Validate(string input, System.Collections.Generic.List<char> delimiters);
    }
}
