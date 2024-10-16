#nullable enable
using System.Collections.Generic;

namespace Calculator.Features
{
    [System.Serializable]
    public sealed class CalculatorData
    {
        public string CurrentInput = string.Empty;
        public List<HistoryData> History = new();
    }

    [System.Serializable]
    public sealed class HistoryData
    {
        public string Input = string.Empty;
        public int? Result;                         // не null только у корректного инпута
    }
}