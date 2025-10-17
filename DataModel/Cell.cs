using Formula;
using System.Text.Json.Serialization;

namespace DataModel
{
    public class Cell
    {
        #region Properties

        public double? Value { get; set; } = null;

        public string? Formula { get; set; } = null;

        [JsonIgnore]
        static public Cell Empty => new Cell();

        [JsonIgnore]
        public bool IsEmpty => this.Equals(Empty);

        #endregion

        #region Methods

        public override bool Equals(object? obj)
        {
            return obj is Cell cell &&
                   Value == cell.Value &&
                   Formula == cell.Formula;
        }

        public double? GetValue(IFormulaHost formulaHost)
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
