using System.Diagnostics;

namespace KingsBountyUtils;
using static SettingsProvider;
public static class SaveFileConvertor
{
    public static void Run(GameSaveSettings saveSettings)
    {
        var saveGameFolders = GetResultSaveFileFolders(saveSettings.LastSaveFolderCount);
        var resultFileNames = new Queue<string>(saveGameFolders);
        
        var saveFolders = Directory
            .GetDirectories(saveSettings.SaveFileFolder)
            .Select(d => new DirectoryInfo(d))
            .OrderBy(d => d.CreationTime)
            .TakeLast(saveSettings.LastSaveFolderCount);

        var resultDirectoryName = $@"{saveSettings.SaveUtilFolder}\{saveSettings.SaveResultFolder}";
        ClearDirectory(resultDirectoryName);
        
        foreach (var saveFolder in saveFolders)
        {
            var convertedSaveFileName = resultFileNames.Dequeue();
            
            var resultFileName = $@"{resultDirectoryName}\{saveSettings.ToConvertFileName}";
            var resultZipName = $@"{resultDirectoryName}\{convertedSaveFileName}";
            File.Copy($@"{saveFolder.FullName}\{saveSettings.SourceSaveFileName}", resultFileName);
            ZipFile(resultFileName, resultZipName);
            File.Delete(resultFileName);
            Console.WriteLine($"Успешная конвертация: {saveFolder.Name} by {saveFolder.CreationTime} to {resultZipName}");
        }
    }

    private static void ZipFile(string sourceFileName, string resultPackName)
    {
        var process = new ProcessStartInfo
        {
            FileName = @"C:\Program Files\7-Zip\7zG.exe",
            Arguments = $"""
                         a -tzip -mx5 -r0 "{resultPackName}.sav" "{sourceFileName}"
                         """,
            WindowStyle = ProcessWindowStyle.Hidden
        };
        using var x = Process.Start(process);
        x?.WaitForExit();
    }

    private static void ClearDirectory(string directoryPath)
    {
        Directory.Delete(directoryPath, true);
        Directory.CreateDirectory(directoryPath);
    }
}