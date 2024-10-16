#nullable enable
using UnityEngine;

namespace Calculator.Services
{
    public sealed class SaveLoadService : ISaveLoadService
    {
        public T? LoadData<T>()
        {
            var key = typeof(T).Name; 
            var jsonData = PlayerPrefs.GetString(key, string.Empty);
            if (string.IsNullOrEmpty(jsonData))
            {
                return default;
            }

            return JsonUtility.FromJson<T>(jsonData);
        }

        public void SaveData<T>(T data)
        {
            var key = typeof(T).Name; 
            var jsonData = JsonUtility.ToJson(data); 

            PlayerPrefs.SetString(key, jsonData); 
            PlayerPrefs.Save(); 
        }
    }
}