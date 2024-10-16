#nullable enable
using Calculator.Services;
using Calculator.Views;
using Nuclear.Services;
using UnityEngine;

namespace Calculator.Features
{
    public sealed class GameEntry : MonoBehaviour
    {
        [SerializeField] private MessageWindow _messageWindow = null!;
        [SerializeField] private CalculatorWindow _calculatorWindow = null!;
        
        [SerializeField] private bool _resetOnStart;

        private void Awake()
        {
            if (_resetOnStart)
            {
                PlayerPrefs.DeleteAll();
            }

            var unityProvider = gameObject.AddComponent<UnityProvider>();
            var saveLoadService = new SaveLoadService();
            var windowsService = new WindowsService(_messageWindow, _calculatorWindow);
            var saveProvider = new SaveProvider(saveLoadService, unityProvider);
            var calculator = new CalculatorController(windowsService, saveProvider);
            
            calculator.OpenCalculatorWindow();
        }
    }
}