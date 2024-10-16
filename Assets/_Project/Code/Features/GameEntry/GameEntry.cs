#nullable enable
using UnityEngine;
using VContainer;

namespace Calculator.Features
{
    public sealed class GameEntry : MonoBehaviour
    {
        [SerializeField] private bool _resetOnStart;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            
            if (_resetOnStart)
            {
                PlayerPrefs.DeleteAll();
            }
            
            var container = DIContainer.Init(transform);

            StartGame(container);
        }

        private static void StartGame(IObjectResolver container)
        {
            var calculator = container.Resolve<ICalculatorController>();
            calculator.OpenCalculatorWindow();
        }
    }
}