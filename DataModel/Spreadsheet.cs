using Formula;
using System.Text.Json.Serialization;

namespace DataModel
{
    public class Spreadsheet : IFormulaHost
    {
        #region Properties

        public string Name { get; set; } = string.Empty;

        public SortedDictionary<Coordinate, Cell> Cells
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
        public int RealColumns => Cells.Any() ? Cells.Max(kvp => kvp.Key.Column) + 1 : 0;

        [JsonIgnore]
        public int RealRows => Cells.Any() ? Cells.Max(kvp => kvp.Key.Row) + 1 : 0;

        #endregion

        #region Methods

        public Cell AddCell(Coordinate coordinate)
        {
            var cell = FindCell(coordinate);
            if (cell == null)
            {
                cell = new Cell();
                Cells.Add(coordinate, cell);

                UpdateColumnsAndRows();
            }

            return cell;
        }

        public void RemoveCell(Coordinate coordinate)
        {
            Cells.Remove(coordinate);

            UpdateColumnsAndRows();
        }

        public void RemoveAllCells()
        {
            Cells.Clear();

            UpdateColumnsAndRows();
        }

        public Cell? MoveCell(Coordinate oldCoordinate, Coordinate newCoordinate)
        {
            Cells.TryGetValue(oldCoordinate, out Cell? cell);
            Cells.Remove(oldCoordinate);
            Cells.Remove(newCoordinate);
            if (cell != null && !cell.IsEmpty)
            {
                Cells.Add(newCoordinate, cell);
            }

            UpdateColumnsAndRows();

            return cell;
        }

        public Cell? FindCell(Coordinate coordinate)
        {
            Cells.TryGetValue(coordinate, out Cell? cell);
            return cell;
        }

        public double GetIdentifierValue(string cellName)
        {
            var cell = FindCell(new Coordinate() { Name = cellName });
            if (cell == null)
            {
                throw new ArgumentException("Invalid cell name");
            }

            return cell.GetValue(this) ?? 0;
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
                var empty = _cells.Where(c => c.Value.IsEmpty)
                                  .Select(kvp => kvp.Key)
                                  .ToList();
                foreach (var coordinate in empty)
                {
                    _cells.Remove(coordinate);
                }
            }

            UpdateColumnsAndRows();
        }

        #endregion

        #region Members

        int _columns = 0;
        int _rows = 0;
        SortedDictionary<Coordinate, Cell> _cells = new SortedDictionary<Coordinate, Cell>();

        #endregion
    }
}
