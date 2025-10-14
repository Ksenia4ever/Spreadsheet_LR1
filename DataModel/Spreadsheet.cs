using Formula;

namespace DataModel
{
    public class Spreadsheet : IFormulaHost
    {
        public string Name { get; set; } = string.Empty;

        public List<Cell> Cells { get; set; } = new List<Cell>();

        public int Columns
        { 
            get => _columns;
            set { _columns = value; UpdateColumnsAndRows(); }
        }
        
        public int Rows
        {
            get => _rows;
            set { _rows = value; UpdateColumnsAndRows(); }
        }

        public int RealColumns => Cells.Max(c => c.Column);

        public int RealRows => Cells.Max(c => c.Row);
       
        public double GetIdentifierValue(string cellName)
        {
            var coord = Utilities.GetCellCoordinate(cellName);
            var cell = Cells.FirstOrDefault(c => c.Column == coord.Item1 && c.Row == coord.Item2);
            if (cell == null)
            {
                throw new ArgumentException("Invalid cell name");
            }

            return cell.GetValue(this);
        }

        void UpdateColumnsAndRows()
        {
            _columns = Math.Max(_columns, RealColumns);
            _rows = Math.Max(_rows, RealRows);
        }

        int _columns = 0;
        int _rows = 0;
    }
}
