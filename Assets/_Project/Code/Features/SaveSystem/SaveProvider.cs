#nullable enable
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Calculator.Services;

namespace Calculator.Features
{
    [UsedImplicitly]
    public sealed class SaveProvider : ISaveProvider
    {
        private readonly ISaveLoadService _saveLoadService;
        private readonly IUnityProvider _unityProvider;
        private readonly List<Action> _saveMethods = new();

        public SaveProvider(ISaveLoadService saveLoadService, IUnityProvider unityProvider)
        {
            _saveLoadService = saveLoadService;
            _unityProvider = unityProvider;
            Data = _saveLoadService.LoadData<SaveData>() ?? new SaveData();
            _unityProvider.OnQuit += Save;
        }

        public void Dispose()
        {
            _unityProvider.OnQuit -= Save;
        }

        private void Save()
        {
            _saveMethods.ForEach(save => save());
            _saveLoadService.SaveData(Data);
        }

        public SaveData Data { get; }
        void ISaveProvider.RegisterSave(Action save) => _saveMethods.Add(save);
    }
}