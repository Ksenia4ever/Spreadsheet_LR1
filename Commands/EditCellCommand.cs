using DataModel;

namespace Commands
{
    public class EditCellCommand : ICommand
    {
        public Spreadsheet? Spreadsheet
        {
            get => _spreadsheet;
            init
            {
                if (_spreadsheet != value)
                {
                    _spreadsheet = value;
                    Init();
                }
            }
        }

        public Coordinate CellCoordinate
        {
            get => _coordinate;
            init
            {
                if (!_coordinate.Equals(value))
                {
                    _coordinate = value;
                    Init();
                }
            }
        }

        public string? Formula { get; set; } = null;

        public double? Value { get; set; } = null;

        public virtual void Execute()
        {
            if (Spreadsheet != null)
            {
                var cell = Spreadsheet.AddCell(CellCoordinate);

                if (cell.Value != Value)
                {
                    cell.Value = Value;
                }

                if (cell.Formula != Formula)
                {
                    cell.Formula = Formula;
                }
            }
        }

        void Init()
        {
            if (Spreadsheet != null)
            {
                var cell = Spreadsheet.FindCell(CellCoordinate);
                if (cell!=null)
                {
                    Formula = cell.Formula;
                    Value = cell.Value;
                }
            }
        }

        Spreadsheet? _spreadsheet = null;
        Coordinate _coordinate = default;
    }
}
