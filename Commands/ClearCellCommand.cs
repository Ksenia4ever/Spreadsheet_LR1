namespace Commands
{
    public class ClearCellCommand : EditCellCommand
    {
        public override void Execute()
        {
            if (Spreadsheet != null)
            {
                Spreadsheet.RemoveCell(CellCoordinate);
                Value = null;
                Formula = null;
            }
        }
    }
}
