using DataModel;

namespace Commands
{
    public class LoadSpreadsheetCommand : ICommand
    {
        public Spreadsheet? Spreadsheet { get; private set; } = null;

        public string FilePath { get; init; } = string.Empty;

        public void Execute()
        {
            var serializer = new SpreadsheetSerializer();
            Spreadsheet = serializer.Read(FilePath);
        }
    }
}
