using DataModel;

namespace Commands
{
    // Add new row at RowCoordinate.Row index,
    // all cells in this and the bottom rows are moved one row down.
    public class AddRowCommand : ICommand
    {
        public Spreadsheet? Spreadsheet { get; init; }

        public Coordinate RowCoordinate { get; init; }

        public virtual void Execute()
        {
            if (Spreadsheet != null)
            {
                if (RowCoordinate.Row > Spreadsheet.Rows)
                {
                    Spreadsheet.Rows = RowCoordinate.Row + 1;
                }
                else if (RowCoordinate.Row > Spreadsheet.RealRows)
                {
                    Spreadsheet.Rows += 1;
                }
                else
                {
                    Spreadsheet.Rows += 1;

                    if (Spreadsheet.Cells.Any())
                    {
                        var colCount = Spreadsheet.RealColumns;
                        var rowCount = Spreadsheet.RealRows;

                        for (var row = rowCount - 1; row >= RowCoordinate.Row; row--)
                        {
                            for (var col = 0; col < colCount; col++)
                            {
                                Spreadsheet.MoveCell(new Coordinate() { Column = col, Row = row },
                                                     new Coordinate() { Column = col, Row = row + 1 });
                            }
                        }

                        Spreadsheet.UpdateCells();
                    }
                }
            }
        }
    }
}
