namespace KingsBountyUtils;

public class GameSaveSettings
{
    public string SaveUtilFolder { get; set; } = @"c:\Users\amwra\Downloads\KingsBountySave";
    public string SaveFileFolder { get; set; } = @"c:\Users\amwra\OneDrive\Документы\My Games\Kings Bounty The Dark Side\$save\base\darkside\";
    public string ItemToSearchFileName { get; set; } = "itemToSearch.txt";
    public string SourceSaveFileName { get; set; } = "data";
    public string SaveResultFolder { get; set; } = "SaveResults";
    public string ToConvertFileName { get; set; } = "savedata";
    public string ResultSaveFileName { get; set; } = "savedata.rpt";
    public int LastSaveFolderCount { get; set; } = 8;
}