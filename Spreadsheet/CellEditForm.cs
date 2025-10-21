namespace SpreadsheetUI
{
    public partial class CellEditForm : Form
    {
        public string? Formula { get; set; } = null;

        public double? Value { get; set; } = null;

        public bool FormulaMode => !string.IsNullOrEmpty(Formula);

        public CellEditForm()
        {
            InitializeComponent();
        }

        void OnLoad(object sender, EventArgs e)
        {
            InitValue();
        }

        void OnOK(object sender, EventArgs e)
        {
            SaveValue();
            DialogResult = DialogResult.OK;
        }

        void InitValue()
        {
            if (FormulaMode)
            {
                _valueTextBox.Text = $"={Formula}";
            }
            else
            {
                _valueTextBox.Text = Value?.ToString() ?? string.Empty;
            }
        }

        void SaveValue()
        {
            var text = _valueTextBox.Text.Trim();
            var formulaMode = text.ElementAtOrDefault(0) == '=';
            if (formulaMode)
            {
                Formula = text.TrimStart('=');
                Value = null;
            }
            else
            {
                Formula = null;
                if (string.IsNullOrEmpty(text))
                {
                    Value = null;
                }
                else
                {
                    if (double.TryParse(text, out double value))
                    {
                        Value = value;
                    }
                    else
                    {
                        MessageBox.Show("Can not parse cell value, it should be number of formula text.",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
