using _project.Scripts.Game.Infrastructure;
using _project.Scripts.GoogleImporter;
using UnityEditor;

namespace GoogleImporter
{
    public class ConfigImportsMenu
    {
        private static string ITEMS_SHEETS_NAME = "LanguageLibrary";
        private static string CREDENTIALS_PAHTH = "language-runner-5e4c8f18d410.json";
        private const string SpreadsheetID = "1p6kab7o2S6QUCZwDyqmX9CNdiKn3cHCEUpXTKnuEOr0";
#if UNITY_EDITOR
        [MenuItem("NikRunner/Import Google Sheets")]
#endif
        public static async void LoadSheetsSettings()
        {
            var sheetsImporter = new GoogleSheetsImporter(CREDENTIALS_PAHTH, SpreadsheetID);
            var config = new Config();
            ServiceLocator.Instance.RegisterInstance(config);
            var parser = new GoogleParser(config);
            await sheetsImporter.DownloadAndParseSheet(ITEMS_SHEETS_NAME, parser);
        }
    }
}