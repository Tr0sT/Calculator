#nullable enable

namespace Calculator.Features
{
    public sealed record CalculationResult(int? Value);

    public static class CalculationResultExtensions
    {
        public static bool IsValid(this CalculationResult calculationResult)
        {
            return calculationResult.Value.HasValue;
        }
    }
}