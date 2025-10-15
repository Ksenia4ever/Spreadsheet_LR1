using System.Text.Json;

namespace DataModel
{
    public class SpreadsheetSerializer
    {
        public void Write(Spreadsheet spreadsheet, string filePath)
        {
            spreadsheet.UpdateCells();

            var json = JsonSerializer.Serialize(spreadsheet);
            File.WriteAllText(filePath, json);
        }

        public Spreadsheet? Read(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var spreadsheet = JsonSerializer.Deserialize<Spreadsheet>(json);
            return spreadsheet;
        }
    }
}
