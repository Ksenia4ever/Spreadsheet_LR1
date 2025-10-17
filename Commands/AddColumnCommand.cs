using DataModel;

namespace Commands
{
    // Add new column at ColumnCoordinate.Column index,
    // all cells in this and the left columns are moved one column to the left.
    public class AddColumnCommand : ICommand
    {
        public Spreadsheet? Spreadsheet { get; init; }

        public Coordinate ColumnCoordinate { get; init; }

        public virtual void Execute()
        {
            if (Spreadsheet != null)
            {
                if (ColumnCoordinate.Column > Spreadsheet.Columns)
                {
                    Spreadsheet.Columns = ColumnCoordinate.Column + 1;
                }
                else if (ColumnCoordinate.Column > Spreadsheet.RealColumns)
                {
                    Spreadsheet.Columns += 1;
                }
                else
                {
                    Spreadsheet.Columns += 1;

                    if (Spreadsheet.Cells.Any())
                    {
                        var colCount = Spreadsheet.RealColumns;
                        var rowCount = Spreadsheet.RealRows;

                        for (var col = colCount - 1; col >= ColumnCoordinate.Column; col--)
                        {
                            for (var row = 0; row < rowCount; row++)
                            {
                                Spreadsheet.MoveCell(new Coordinate() { Column = col, Row = row },
                                                     new Coordinate() { Column = col + 1, Row = row });
                            }
                        }

                        Spreadsheet.UpdateCells();
                    }
                }
            }
        }
    }
}
