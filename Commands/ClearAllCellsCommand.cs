using DataModel;

namespace Commands
{
    public class ClearAllCellsCommand : ICommand
    {
        public Spreadsheet? Spreadsheet { get; init; } = null;

        public void Execute()
        {
            if (Spreadsheet != null)
            {
                Spreadsheet.RemoveAllCells();
            }
        }
    }
}
