#nullable enable
using System;
using UnityEngine;

namespace Calculator.Features
{
    public sealed class UnityProvider : MonoBehaviour, IUnityProvider
    {
        public event Action? OnQuit;
        
        private void OnApplicationQuit()
        {
            OnQuit?.Invoke();
        }
    }
}