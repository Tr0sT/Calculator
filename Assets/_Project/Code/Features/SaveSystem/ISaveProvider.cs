#nullable enable

using System;

namespace Calculator.Features
{
    public interface ISaveProvider : IDisposable
    {
        SaveData Data { get; }

        void RegisterSave(Action save);
    }
}