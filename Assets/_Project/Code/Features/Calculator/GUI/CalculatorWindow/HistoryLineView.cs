#nullable enable
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.Views
{
    public sealed class HistoryLineView : MonoBehaviour
    {
        [SerializeField] private Text _text = null!;

        public void Init(string text)
        {
            _text.text = text;
        }
    }
}