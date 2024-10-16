#nullable enable
using System.Text.RegularExpressions;

namespace Calculator.Features
{
    public static class CalculatorHelper
    {
        public static CalculationResult ParseAndCalculateResult(InputString value)
        {
            var pattern = @"^(\d+)\+(\d+)$";
            var match = Regex.Match(value.Value, pattern);
            if (!match.Success)
            {
                return new(null);
            }

            var result = 0;
            try
            {
                var number1 = int.Parse(match.Groups[1].Value);
                var number2 = int.Parse(match.Groups[2].Value);
                result = number1 + number2;
            }
            catch
            {
                return new(null);
            }

            return new(result);
        }
    }
}