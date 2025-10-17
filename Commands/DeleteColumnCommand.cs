using DataModel;

namespace Commands
{
    public class DeleteColumnCommand : AddColumnCommand
    {
        public override void Execute()
        {
            if (Spreadsheet != null)
            {
                if (ColumnCoordinate.Column > Spreadsheet.Columns)
                {
                    // do nothing
                }
                else if (ColumnCoordinate.Column > Spreadsheet.RealColumns)
                {
                    Spreadsheet.Columns -= 1;
                }
                else
                {
                    if (Spreadsheet.Cells.Any())
                    {
                        var colCount = Spreadsheet.RealColumns;
                        var rowCount = Spreadsheet.RealRows;

                        for (var col = ColumnCoordinate.Column; col < colCount; col++)
                        {
                            for (var row = 0; row < rowCount; row++)
                            {
                                Spreadsheet.MoveCell(new Coordinate() { Column = col + 1, Row = row },
                                                     new Coordinate() { Column = col, Row = row });
                            }
                        }

                        Spreadsheet.UpdateCells();
                    }

                    Spreadsheet.Columns -= 1;
                }
            }
        }
    }
}
