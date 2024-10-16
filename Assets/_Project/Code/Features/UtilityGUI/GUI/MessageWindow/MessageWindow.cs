#nullable enable
using Calculator.ViewModels;
using Nuclear.Services;
using Nuclear.Services.GUI;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.Views
{
    [Path("GUI/MessageWindow/MessageWindow")]
    public class MessageWindow : MWindow<IMessageWindowViewModel>
    {
        [SerializeField] private Text _messageText = null!;
        
        public override void Init()
        {
            base.Init();
            _messageText.text = _viewModel.Message;
        }
    }
}