namespace KingsBountyUtils;

public class GameSaveSettings
{
    public string SaveUtilFolder { get; init; } = @"c:\Users\amwra\Downloads\KingsBountySave";
    public string SaveFileFolder { get; init; } = @"c:\Users\amwra\OneDrive\Документы\My Games\Kings Bounty The Dark Side\$save\base\darkside\";
    public string ItemToSearchFileName { get; init; } = "itemToSearch.txt";
    public string SourceSaveFileName { get; init; } = "data";
    public string SaveResultFolder { get; init; } = "SaveResults";
    public string ToConvertFileName { get; init; } = "savedata";
    public string ResultSaveFileName { get; init; } = "savedata.rpt";
    public int LastSaveFolderCount { get; init; } = 8;
}