using System.Text.Json;

namespace KingsBountyUtils;

public static class SettingsProvider
{
    private const string ResultFileNameSchema = "Save{0}";
    private const string SettingsFileName = "settings.json";


    public static GameSaveSettings? GetSettings()
    {
        GameSaveSettings? result = null;
        try
        {
            var jsonString = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}{SettingsFileName}");
            
            jsonString = jsonString.Replace(@"\", @"\\");
            
            result = JsonSerializer.Deserialize<GameSaveSettings>(jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ОШИБКА: {ex.Message}");
        }
        return result;
    }
    
    public static IEnumerable<string> GetResultSaveFileFolders(int lastSaveFolderCount)
    {
        for (var i = 1; i <= lastSaveFolderCount; i++)
        {
            yield return string.Format(ResultFileNameSchema, i);
        }
    }
}