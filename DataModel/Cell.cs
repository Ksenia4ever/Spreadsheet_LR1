using Formula;
using System.Text.Json.Serialization;

namespace DataModel
{
    public class Cell
    {
        #region Properties

        public double? Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                }
            }
        }

        public string? Formula
        {
            get => _formula;
            set
            {
                if (_formula != value)
                {
                    _formula = value;
                    ResetCalculatedValue();
                }
            }
        }

        [JsonIgnore]
        public string? FormulaError
        {
            get => _formulaError;
            private set
            {
                if (_formulaError != value)
                {
                    _formulaError = value;
                }
            }
        }

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

        public double? GetValue(ICellHost host)
        {
            if (!string.IsNullOrEmpty(Formula))
            {
                if (Value == null &&
                    FormulaError == null)
                {
                    try
                    {
                        var calculator = new FormulaCalculator() { Host = host };
                        calculator.Parse(Formula);

                        if (IsInCalculation)
                        {
                            FormulaError = "Recursive calculation!";
                        }
                        else
                        {
                            IsInCalculation = true;

                            Value = calculator.Calculate();
                        }
                    }
                    catch (Exception ex)
                    {
                        // due to recursion we can cacth multiple exception at forumula calculation.
                        // we need to save the first only.
                        if (FormulaError == null)
                        {
                            FormulaError = ex.Message;
                        }
                    }
                    finally
                    {
                        IsInCalculation = false;
                    }
                }

                if (FormulaError != null)
                {
                    var thisCoordinate = host.FindCoordinate(this);
                    throw new InvalidOperationException($"{thisCoordinate.Name}: {FormulaError}");
                }
            }

            return Value;
        }

        public void ResetCalculatedValue()
        {
            if (!string.IsNullOrEmpty(Formula))
            {
                Value = null;
                FormulaError = null;
                IsInCalculation = false;
            }
        }

        #endregion

        #region Helpers

        bool IsInCalculation { get; set; } = false;

        #endregion

        #region Members

        double? _value = null;
        string? _formula = null;
        string? _formulaError = null;

        #endregion
    }
}
