using Formula;

namespace DataModel
{
    public class Cell
    {
        #region Properties

        public int Column { get; set; } = -1;
        public int Row { get; set; } = -1;
        public double Value { get; set; } = 0;
        public string Formula { get; set; } = string.Empty;

        static public Cell Empty => new Cell();

        public bool IsEmpty => this.Equals(Empty);

        #endregion

        #region Methods

        public override bool Equals(object? obj)
        {
            return obj is Cell cell &&
                   Column == cell.Column &&
                   Row == cell.Row &&
                   Value == cell.Value &&
                   Formula == cell.Formula;
        }

        public double GetValue(IFormulaHost formulaHost)
        {
            if (!string.IsNullOrEmpty(Formula))
            {
                if (IsInCalculation)
                {
                    throw new InvalidOperationException("Recursive calculation!");
                }

                IsInCalculation = true;

                var calculator = new FormulaCalculator() { Host = formulaHost };
                calculator.Parse(Formula);
                Value = calculator.Calculate();

                IsInCalculation = false;
            }

            return Value;
        }

        #endregion

        #region Helpers

        bool IsInCalculation { get; set; } = false;

        #endregion
    }
}
