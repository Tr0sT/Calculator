#nullable enable
namespace Calculator.Services
{
    public interface ISaveLoadService
    {
        T? LoadData<T>();
        void SaveData<T>(T data);
    }
}