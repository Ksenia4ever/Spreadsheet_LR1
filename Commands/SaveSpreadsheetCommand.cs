using DataModel;

namespace Commands
{
    public class SaveSpreadsheetCommand : ICommand
    {
        public Spreadsheet? Spreadsheet { get; init; } = null;

        public string FilePath { get; init; } = string.Empty;

        public void Execute()
        {
            if (Spreadsheet != null)
            {
                var serializer = new SpreadsheetSerializer();
                serializer.Write(Spreadsheet, FilePath);
            }
        }
    }
}
