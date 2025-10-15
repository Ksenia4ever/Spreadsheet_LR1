namespace DataModel
{
    public struct Coordinate : IComparable<Coordinate>
    {
        public int Column { get; init; }
        public int Row { get; init; }


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
