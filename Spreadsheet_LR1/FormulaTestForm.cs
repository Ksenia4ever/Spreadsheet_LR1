using DataModel;
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
                var ss = new Spreadsheet();
                ss.AddCell("D10").Value = 50;
                ss.AddCell("B1").Value = 30;
                ss.AddCell("A1").Value = 10;
                ss.AddCell("B2").Value = 40;
                ss.AddCell("A2").Value = 20;
                ss.OrderCells();

                var formula = formulaTextBox.Text;

                var calculator = new FormulaCalculator() { Host = ss };
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
