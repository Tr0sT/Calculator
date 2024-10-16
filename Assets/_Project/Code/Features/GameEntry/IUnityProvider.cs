#nullable enable

using System;

namespace Calculator.Features
{
    public interface IUnityProvider
    {
        event Action? OnQuit;
    }
}