using Formula;

namespace Spreadsheet_LR1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnCalculateClick(object sender, EventArgs e)
        {
            var formula = formulaTextBox.Text;

            var calculator = new FormulaCalculator();
            calculator.Parse(formula);
            var res = calculator.Calculate();

            resultTextBox.Text = $"{res:f2}";

        }
    }
}
