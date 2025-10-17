using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
    public class DeleteRowCommand : AddRowCommand
    {
        public override void Execute()
        {
            if (Spreadsheet != null)
            {
                if (RowCoordinate.Row > Spreadsheet.Rows)
                {
                    // do nothing
                }
                else if (RowCoordinate.Row > Spreadsheet.RealRows)
                {
                    Spreadsheet.Rows -= 1;
                }
                else
                {
                    if (Spreadsheet.Cells.Any())
                    {
                        var colCount = Spreadsheet.RealColumns;
                        var rowCount = Spreadsheet.RealRows;

                        for (var row = RowCoordinate.Row; row < rowCount; row++)
                        {
                            for (var col = 0; col < colCount; col++)
                            {
                                Spreadsheet.MoveCell(new Coordinate() { Column = col, Row = row + 1 },
                                                     new Coordinate() { Column = col, Row = row });
                            }
                        }

                        Spreadsheet.UpdateCells();
                    }

                    Spreadsheet.Rows -= 1;
                }
            }
        }

    }
}
