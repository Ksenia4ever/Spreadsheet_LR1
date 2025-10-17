namespace DataModel
{
    public static class Utilities
    {
        static public Coordinate GetCellCoordinate(string cellName)
        {
            if (string.IsNullOrWhiteSpace(cellName))
            {
                throw new ArgumentException("Cell name is empty.", nameof(cellName));
            }

            cellName = cellName.Trim();

            long col1 = 0; // column in 1-based Excel semantics
            long row1 = 0; // row in 1-based Excel semantics
            var i = 0;

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

            if (col1 > int.MaxValue ||
                row1 > int.MaxValue)
            {
                throw new OverflowException("Column or row exceeds Int32 range.");
            }

            // 0-based index
            var col0 = (int)col1 - 1;
            var row0 = (int)row1 - 1;

            return new Coordinate() { Column = col0, Row = row0 };
        }

        static public string GetCellName(Coordinate coordinate)
        {
            var cellName = $"{GetColumnName(coordinate.Column)}{GetRowName(coordinate.Row)}";
            return cellName;
        }

        static public string GetColumnName(int column)
        {
            if (column < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(column), "Invalid column index.");
            }

            string columnName = "";
            while (column >= 0)
            {
                int remainder = column % 26;
                columnName = (char)(remainder + 'A') + columnName;
                column = (column / 26) - 1;
            }
            return columnName;
        }

        static public string GetRowName(int rowIndex)
        {
            if (rowIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rowIndex), "Invalid row index.");
            }

            return $"{rowIndex + 1}";
        }
    }
}
