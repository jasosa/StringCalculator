using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Source
{
    public class Validator : IValidator
    {
        public bool Validate(string input, List<char> delimiters)
        {
            return ValidateTwoConsecutiveSeparators(input, delimiters) 
                && ValidateNegativeNumbers(input);
        }

        private bool ValidateNegativeNumbers(string input)
        {
            var pattern = @"-\d";
            var reg = new Regex(pattern);
            MatchCollection matches = reg.Matches(input);
            if (matches.Count > 0)
            {
                LastErrorMessage = String.Format("Negatives not allowed: {0}", matches[0].Value);
                return false;
            }

            return true;
        }

        private bool ValidateTwoConsecutiveSeparators(string input, List<char> delimiters)
        {
            foreach (char delimiter in delimiters)
            {
                var pattern = String.Format(@"{0}{1}", delimiter, "{2,}");
                var reg = new Regex(pattern);
                if (reg.IsMatch(input))
                {
                    LastErrorMessage = "Two consecutive separators";
                    return false;
                }
            }

            return true;
        }

        public string LastErrorMessage { get; set; }
    }
}
