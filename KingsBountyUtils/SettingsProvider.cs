using System.Text.Json;

namespace KingsBountyUtils;

public static class SettingsProvider
{
    private const string ResultFileNameSchema = "Save{0}";
    private const string SettingsFileName = "settings.json";

    private static GameSaveSettings? _lastGeneratedSettings;

    public static GameSaveSettings? GetSettings()
    {
        try
        {
            var jsonString = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}{SettingsFileName}");
            
            jsonString = jsonString.Replace(@"\", @"\\");
            
            _lastGeneratedSettings = JsonSerializer.Deserialize<GameSaveSettings>(jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ОШИБКА: {ex.Message}");
        }
        return _lastGeneratedSettings;
    }
    
    public static IEnumerable<string> GetResultSaveFileFolders(int lastSaveFolderCount)
    {
        for (var i = 1; i <= lastSaveFolderCount; i++)
        {
            yield return string.Format(ResultFileNameSchema, i);
        }
    }
}