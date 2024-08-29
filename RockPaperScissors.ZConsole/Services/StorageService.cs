using System.Text.Json;

namespace RockPaperScissors.ZConsole.Services;

public class StorageService
{
    public void WriteToJsonFile<T>(string filePath, T objectToWrite)
    {
        if (!File.Exists(filePath))
            File.Create(filePath).Dispose();

        File.WriteAllText(filePath, JsonSerializer.Serialize(objectToWrite));
    }

    public T? ReadFromJsonFile<T>(string filePath)
    {
        return !File.Exists(filePath)
            ? default
            : JsonSerializer.Deserialize<T>(File.ReadAllText(filePath));
    }
}