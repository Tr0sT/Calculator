#nullable enable
namespace Calculator.Features
{
    public sealed class HistoryItem : IHistoryItem
    {
        public InputString Input { get; }
        public CalculationResult Result { get; }

        public HistoryItem(InputString input, CalculationResult result)
        {
            Input = input;
            Result = result;
        }

        public HistoryData ToData()
        {
            return new HistoryData
            {
                Input = Input.Value,
                Result = Result.Value
            };
        }
    }
}