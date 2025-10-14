namespace DataModel
{
    public class Cell
    {
        public int Column { get; set; } = -1;
        public int Row { get; set; } = -1;
        public double Value { get; set; } = 0;
        public string Formula { get; set; } = string.Empty;

        static public Cell Empty => new Cell();

        public bool IsEmpty => this.Equals(Empty);

        public override bool Equals(object? obj)
        {
            return obj is Cell cell &&
                   Column == cell.Column &&
                   Row == cell.Row &&
                   Value == cell.Value &&
                   Formula == cell.Formula;
        }
    }
}
