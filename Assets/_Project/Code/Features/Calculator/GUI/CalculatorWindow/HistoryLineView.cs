#nullable enable
using Calculator.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.Views
{
    public sealed class HistoryLineView : MonoBehaviour
    {
        [SerializeField] private Text _text = null!;

        public void Init(IHistoryLineViewModel viewModel)
        {
            _text.text = viewModel.Text;
        }
    }
}