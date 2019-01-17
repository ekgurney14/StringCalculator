using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringKata
{
    public static class StringCalculator
    {
        public static int Calculate(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var (modifiedNumbers, delimiters) = CreateDelimiters(numbers);
            return CalculateSum(modifiedNumbers, delimiters);

        }

        private static int CalculateSum(string modifiedNumbers, List<char> delimiters)
        {
            var enumerable = modifiedNumbers
                .Split(delimiters.ToArray())
                .Select(int.Parse).Where(n => n <= 1000)
                .ToList();

            if (enumerable.Any(i => i < 0))
                throw new InvalidOperationException("whatever");
            return enumerable
                .Sum();
        }

        private static (string, List<char>) CreateDelimiters(string numbers)
        {
            var delimiters = new List<char> {',', '\n'};

            var regEx = new Regex(@"//(.*)\n");
            if (regEx.IsMatch(numbers))
            {
                var matches = regEx.Match(numbers);
                var delimiter = matches.Groups[1];
                delimiters.Add(delimiter.Value[0]);
                var valueLength = matches.Groups[0].Value.Length;
                numbers = numbers.Substring(valueLength, numbers.Length - valueLength);
            }

            return (numbers, delimiters);
        }
    }
}
