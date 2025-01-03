
namespace KingsBountyUtils;

public static class KingsBountyItemTrim
{
    /// <summary>
    /// Очистить файл с артефактами от дубликатов, чтоб быстрей создавался сейв
    /// </summary>
    public static void ClearDuplicates()
    {
        var file = new FileInfo("Game/Artefacts.txt");
        var resultFile = new FileInfo("ArtefactsResult.txt");
        var fileData = File.ReadAllLines(file.FullName);
        var result = HandleFileData(fileData);
        File.WriteAllLines(resultFile.FullName, result);
    }

    private static IEnumerable<string> HandleFileData(IEnumerable<string> fileData)
    {
        var previousRow = string.Empty;
        foreach (var row in fileData)
        {
            if (row == previousRow) continue;
            
            previousRow = row;
            yield return row;
        }
    }
}