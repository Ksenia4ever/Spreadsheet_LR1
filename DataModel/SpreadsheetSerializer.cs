using System.Text.Json;

namespace DataModel
{
    public class SpreadsheetSerializer
    {
        public JsonSerializerOptions Options { get; set; } = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new CoordinateSerializeConvertor() }
        };

        public void Write(Spreadsheet spreadsheet, string filePath)
        {
            spreadsheet.UpdateCells();

            var json = JsonSerializer.Serialize(spreadsheet, Options);
            File.WriteAllText(filePath, json);
        }

        public Spreadsheet Read(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var spreadsheet = JsonSerializer.Deserialize<Spreadsheet>(json, Options);
            if (spreadsheet == null)
            {
                throw new InvalidOperationException("Invalid or empty json file");
            }

            return spreadsheet;
        }
    }
}
