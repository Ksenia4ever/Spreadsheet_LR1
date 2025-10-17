using System.Text.Json.Serialization;

namespace DataModel
{
    public struct Coordinate : IComparable<Coordinate>
    {
        public int Column { get; init; }
        public int Row { get; init; }

        [JsonIgnore]
        public string Name
        { 
            get => Utilities.GetCellName(this);
            init
            {
                if (!Name.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                {
                    this = Utilities.GetCellCoordinate(value);
                }
            }
        }

        [JsonIgnore]
        public string RowName
        {
            get => Utilities.GetRowName(Row);
            init
            {
                if (!RowName.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                {
                    Row = Utilities.GetCellCoordinate($"A{value}").Row;
                }
            }
        }

        [JsonIgnore]
        public string ColumnName
        {
            get => Utilities.GetColumnName(Column);
            init
            {
                if (!ColumnName.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                {
                    Column = Utilities.GetCellCoordinate($"{value}1").Column;
                }
            }
        }

        public int CompareTo(Coordinate other)
        {
            var res = Row.CompareTo(other.Row);
            if (res == 0)
            {
                res = Column.CompareTo(other.Column);
            }

            return res;
        }
    }
}
