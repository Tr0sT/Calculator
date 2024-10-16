#nullable enable
namespace Calculator.Features
{
    public interface IHistoryItem
    {
        InputString Input { get; }
        CalculationResult Result { get; }
    }
}