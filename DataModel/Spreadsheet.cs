using Formula;
using System.Text.Json.Serialization;

namespace DataModel
{
    public class Spreadsheet : IFormulaHost
    {
        #region Properties

        public string Name { get; set; } = string.Empty;

        public List<Cell> Cells
        {
            get => _cells;
            init
            {
                if (_cells != value)
                {
                    _cells = value;
                    UpdateCells();
                }
            }
        }

        public int Columns
        {
            get => _columns;
            set
            {
                if (_columns != value)
                {
                    _columns = value;
                    UpdateColumnsAndRows();
                }
            }
        }
        
        public int Rows
        {
            get => _rows;
            set
            {
                if (_rows != value)
                {
                    _rows = value;
                    UpdateColumnsAndRows();
                }
            }
        }

        [JsonIgnore]
        public int RealColumns => Cells.Any() ? Cells.Max(c => c.Coordinate.Column) : 0;

        [JsonIgnore]
        public int RealRows => Cells.Any() ? Cells.Max(c => c.Coordinate.Row) : 0;

        #endregion

        #region Methods

        public Cell AddCell(string cellName)
        {
            var coord = Utilities.GetCellCoordinate(cellName);
            return AddCell(coord);
        }

        public Cell AddCell(Coordinate coordinate)
        {
            var cell = FindCell(coordinate);
            if (cell == null)
            {
                cell = new Cell() { Coordinate = coordinate };
                Cells.Add(cell);
            }

            return cell;
        }

        public void RemoveCell(string cellName)
        {
            var coord = Utilities.GetCellCoordinate(cellName);
            RemoveCell(coord);
        }

        public void RemoveCell(Coordinate coordinate)
        {
            var cell = FindCell(coordinate);
            if (cell != null)
            {
                Cells.Remove(cell);
            }
        }

        public Cell? MoveCell(Coordinate oldCoordinate, Coordinate newCoordinate)
        {
            var cell = FindCell(oldCoordinate);
            if (cell != null)
            {
                RemoveCell(newCoordinate);
                RemoveCell(oldCoordinate);

                var newCell = AddCell(newCoordinate);
                newCell.Value = cell.Value;
                newCell.Formula = cell.Formula;

                cell = newCell;
            }

            return cell;
        }

        public Cell? FindCell(string cellName)
        {
            var coord = Utilities.GetCellCoordinate(cellName);
            return FindCell(coord);
        }

        public Cell? FindCell(Coordinate coordinate)
        {
            var cell = Cells.FirstOrDefault(c => c.Coordinate.Equals(coordinate));
            return cell;
        }

        public double GetIdentifierValue(string cellName)
        {
            var cell = FindCell(cellName);
            if (cell == null)
            {
                throw new ArgumentException("Invalid cell name");
            }

            return cell.GetValue(this) ?? 0;
        }

        public void OrderCells()
        {
            _cells = _cells.OrderBy(c => c.Coordinate)
                           .ToList();
        }

        public void UpdateColumnsAndRows()
        {
            _columns = Math.Max(_columns, RealColumns);
            _rows = Math.Max(_rows, RealRows);
        }

        public void UpdateCells()
        {
            // remove empty
            {
                var empty = _cells.Select((c, i) => KeyValuePair.Create(c, i))
                                  .Where(c => c.Key.IsEmpty)
                                  .ToList();
                foreach (var kvp in empty)
                {
                    _cells.RemoveAt(kvp.Value);
                }
            }

            // remove duplicates (cells with the same coordinates)
            for (var index = _cells.Count - 1; index >= 0; index--)
            {
                var cell = _cells[index];
                var duplicates = _cells.Take(index)
                                       .Select((c, i) => KeyValuePair.Create(c, i))
                                       .Where(kvp => kvp.Key.Coordinate.Equals(cell.Coordinate))
                                       .Reverse()
                                       .ToList();
                foreach(var kvp in duplicates)
                {
                    _cells.RemoveAt(kvp.Value);
                }
                index -= duplicates.Count;
            }

            OrderCells();

            UpdateColumnsAndRows();
        }

        #endregion

        #region Members

        int _columns = 0;
        int _rows = 0;
        List<Cell> _cells = new List<Cell>();

        #endregion
    }
}
