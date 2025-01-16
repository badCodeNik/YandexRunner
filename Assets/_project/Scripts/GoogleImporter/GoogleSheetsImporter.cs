using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using UnityEngine;

namespace GoogleImporter
{
    public class GoogleSheetsImporter
    {
        private readonly SheetsService _service;
        private readonly List<string> _headers = new();
        private readonly string _spreadsheetId;
        private readonly IGoogleSheetParser _parser;
        private static string CREDENTIALS_PAHTH = "language-runner-5e4c8f18d410.json";
        private const string SpreadsheetID = "1p6kab7o2S6QUCZwDyqmX9CNdiKn3cHCEUpXTKnuEOr0";
        private static string ITEMS_SHEETS_NAME = "LanguageLibrary";


        public GoogleSheetsImporter(IGoogleSheetParser parser)
        {
            _spreadsheetId = SpreadsheetID;
            _parser = parser;

            GoogleCredential credential;
            using (var stream =
                   new System.IO.FileStream(CREDENTIALS_PAHTH, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(SheetsService.Scope.SpreadsheetsReadonly);
            }

            _service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });
        }

        public async Task DownloadAndParseSheet()
        {
            Debug.Log($"Starting downloading sheet (${ITEMS_SHEETS_NAME})...");

            var range = $"{ITEMS_SHEETS_NAME}!A1:Z";
            var request = _service.Spreadsheets.Values.Get(_spreadsheetId, range);

            ValueRange response;
            try
            {
                response = await request.ExecuteAsync();
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Error retrieving Google Sheets data: {e.Message}");
                return;
            }

            if (response != null && response.Values != null)
            {
                var tableArray = response.Values;
                Debug.Log($"Sheet downloaded successfully: {ITEMS_SHEETS_NAME}. Parsing started.");

                var firstRow = tableArray[0];
                foreach (var cell in firstRow)
                {
                    _headers.Add(cell.ToString());
                }

                var rowsCount = tableArray.Count;
                for (var i = 1; i < rowsCount; i++)
                {
                    var row = tableArray[i];
                    var rowLength = row.Count;

                    for (var j = 0; j < rowLength; j++)
                    {
                        var cell = row[j];
                        var header = _headers[j];

                        _parser.Parse(header, cell.ToString());
                    }
                }

                Debug.Log($"Sheet parsed successfully.");
            }
            else
            {
                Debug.LogWarning("No data found in Google Sheets.");
            }
        }
    }

    public interface IGoogleSheetParser
    {
        void Parse(string header, string token);
    }
}