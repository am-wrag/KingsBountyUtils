using System.Text.Json.Serialization;

namespace KingsBountyUtils;

public class GameSaveSettings
{
    [JsonPropertyName("SaveUtilFolder")]   
    public string SaveUtilFolder { get; init; } = @"c:\Users\amwra\Downloads\KingsBountySave";
    
    [JsonPropertyName("SaveFileFolder")]   
    public string SaveFileFolder { get; init; } = @"c:\Users\amwra\OneDrive\Документы\My Games\Kings Bounty The Dark Side\$save\base\darkside\";

    [JsonPropertyName("ItemToSearchFileName")]   
    public string ItemToSearchFileName { get; init; } = "itemToSearch.txt";

    [JsonPropertyName("LastSaveFolderCount")]   
    public int LastSaveFolderCount { get; init; } = 8;

    public string SourceSaveFileName { get; init; } = "data";
    public string SaveResultFolder { get; init; } = "SaveResults";
    public string ToConvertFileName { get; init; } = "savedata";
    public string ResultSaveFileName { get; init; } = "savedata.rpt";
}