using Formula;

namespace Spreadsheet_LR1
{
    public partial class FormulaTestForm : Form
    {
        public FormulaTestForm()
        {
            InitializeComponent();
        }

        private void OnCalculateClick(object sender, EventArgs e)
        {
            try
            {
                var formula = formulaTextBox.Text;

                var calculator = new FormulaCalculator();
                calculator.Parse(formula);
                var res = calculator.Calculate();

                resultTextBox.Text = $"{res:f2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
