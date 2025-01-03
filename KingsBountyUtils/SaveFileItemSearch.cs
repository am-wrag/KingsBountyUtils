using System.Text;

namespace KingsBountyUtils;
using static SettingsProvider;

public class SaveFileItemSearch
{
    private const string ResultFoundFileName = "foundItems.txt";
    private const string ResultNotFoundFile = "notFoundItems.txt";

    /// <summary>
    /// Поиск в файле сохранений предметов из списка
    /// </summary>
    public static void ScanForMatchItems(GameSaveSettings saveSettings)
    {
        var resultSaveFileFolderNames = GetResultSaveFileFolders(saveSettings.LastSaveFolderCount);
        
        foreach (var folderName in resultSaveFileFolderNames)
        {
            ScanFileByFolder(folderName, saveSettings);
        }
    }

    private static void ScanFileByFolder(string saveFileFolderName, GameSaveSettings saveSettings)
    {
        var resulList = new List<string>();

        var saveFileFolder = $@"{saveSettings.SaveUtilFolder}\{saveSettings.SaveResultFolder}\{saveFileFolderName}";
        var saveFilePath = $@"{saveFileFolder}\{saveSettings.ResultSaveFileName}";
        
        var encoding = Encoding.GetEncoding("Windows-1251");
        if (!File.Exists(saveFilePath))
        {
            Console.WriteLine($"ОШИБКА! Файл не найден! {saveFilePath}");
            return;
        }

        var saveFileRows = File.ReadLines(saveFilePath, encoding);
        var itemsToSearch = GetItemNameAndPriority(saveSettings).ToList();
        
        foreach (var saveFileRow in saveFileRows)
        {
            foreach (var itemToSearch in itemsToSearch.Where(itemToSearch => ContainsItem(saveFileRow, itemToSearch.itemName)))
            {
                resulList.Add(saveFileRow);
                itemsToSearch.Remove(itemToSearch);
                break;
            }
        }
        
        File.WriteAllLines($@"{saveFileFolder}\{ResultFoundFileName}", resulList);
        File.WriteAllLines($@"{saveFileFolder}\{ResultNotFoundFile}", itemsToSearch.Select(r => $"{r.itemName} // {r.itemPriority} {r.itemNote}"));
        Console.WriteLine($"Сканирование {saveFileFolder} успешно!");
    }

    private static bool ContainsItem(string saveFileRow, string itemName)
    {
        return saveFileRow.Contains(itemName, StringComparison.CurrentCultureIgnoreCase);
    }

    private static IEnumerable<(string itemName, string? itemPriority, string? itemNote)> GetItemNameAndPriority(GameSaveSettings saveSettings)
    {
        var itemToSearchFilePath = $@"{Directory.GetCurrentDirectory()}\{saveSettings.ItemToSearchFileName}";
        var itemsToSearch = File.ReadAllLines(itemToSearchFilePath);
        foreach (var item in itemsToSearch)
        {
            var itemValues = item.Split("@");
            yield return itemValues.Length switch
            {
                1 => (itemValues[0], null, null),
                2 => (itemValues[0], itemValues[1], null),
                _ => (itemValues[0], itemValues[1], itemValues[2])
            };
        }
    }
}