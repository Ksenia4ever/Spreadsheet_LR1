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

        static public Tuple<int, int> GetCellCoordinate(string cellName)
        {
            if (string.IsNullOrWhiteSpace(cellName))
            {
                throw new ArgumentException("Cell name is empty.", nameof(cellName));
            }

            cellName = cellName.Trim();

            long col1 = 0; // column in 1-based Excel semantics
            long row1 = 0; // row in 1-based Excel semantics
            var i = 0;

            // while (i < n && cellName[i] == '$') i++;

            // 1) Convert column letters (A..Z) -> 1-based
            var lettersStart = i;
            while (i < cellName.Length && char.IsLetter(cellName[i]))
            {
                char c = char.ToUpperInvariant(cellName[i]);
                if (c < 'A' || c > 'Z')
                {
                    throw new FormatException($"Invalid column letter: '{cellName[i]}'.");
                }

                col1 = col1 * 26 + (c - 'A' + 1);
                i++;
            }

            if (i == lettersStart)
            {
                throw new FormatException("Missing column letters at the start (e.g., 'A', 'AA').");
            }

            // while (i < n && cellName[i] == '$') i++;

            // 2) Convert row number letters -> 1-based
            var digitsStart = i;
            while (i < cellName.Length)
            {
                char d = cellName[i];
                if (!char.IsDigit(d))
                {
                    throw new FormatException($"Invalid character in row part: '{d}'.");
                }

                row1 = row1 * 10 + (d - '0');
                i++;
            }

            if (i == digitsStart)
            {
                throw new FormatException("Missing row digits at the end (e.g., '1', '23').");
            }

            if (row1 <= 0)
            {
                throw new FormatException("Row number must be >= 1.");
            }

            if (col1 > int.MaxValue || row1 > int.MaxValue)
            {
                throw new OverflowException("Column or row exceeds Int32 range.");
            }

            // 0-based
            var col0 = (int)col1 - 1;
            var row0 = (int)row1 - 1;

            return Tuple.Create(col0, row0);
        }

        public double GetIdentifierValue(string cellName)
        {
            var coord = GetCellCoordinate(cellName);
            var cell = Cells.FirstOrDefault(c => c.Column == coord.Item1 && c.Row == coord.Item2);
            if (cell == null)
            {
                throw new ArgumentException("Invalid cell name");
            }

            return cell.Value;
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
