// See https://aka.ms/new-console-template for more information

using System.Text;
using KingsBountyUtils;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

var saveGameSettings = SettingsProvider.GetSettings();
if (saveGameSettings == null)
{
    Console.WriteLine("ОШИБКА! Не корректный файл настроек");
    return;
}

if (args.Length != 0 && args[0] == "-s")
{
    Console.WriteLine("Начала сканирования сейва");
    SaveFileItemSearch.ScanForMatchItems(saveGameSettings);
}

if (args.Length == 0 || args[0] == "-c")
{
    Console.WriteLine("Начало конвертации сейвов");
    SaveFileConvertor.Run(saveGameSettings);
}
Console.WriteLine("Работа окончена.");
Console.WriteLine("Нажмите любую клавишу чтобы выйти");
Console.ReadKey();


