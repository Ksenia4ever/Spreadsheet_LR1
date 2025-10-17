using Commands;
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
                ss.AddCell(new Coordinate() { Name = "D10" }).Value = 50;
                ss.AddCell(new Coordinate() { Name = "B1" }).Value = 30;
                ss.AddCell(new Coordinate() { Name = "A1" }).Value = 10;
                ss.AddCell(new Coordinate() { Name = "B2" }).Value = 40;
                ss.AddCell(new Coordinate() { Name = "A2" }).Value = 20;

                var saveCmd = new SaveSpreadsheetCommand() { Spreadsheet = ss, FilePath = "C:\\Temp\\ss.json" };
                saveCmd.Execute();

                var addColCmd = new AddColumnCommand() { Spreadsheet = ss, ColumnCoordinate = new Coordinate() { ColumnName = "B" } };
                addColCmd.Execute();

                var addRowCmd = new AddRowCommand() { Spreadsheet = ss, RowCoordinate = new Coordinate() { RowName = "2" } };
                addRowCmd.Execute();

                var clearCmd = new ClearCellCommand() { Spreadsheet = ss, CellCoordinate = new Coordinate() { Name = "A1" } };
                clearCmd.Execute();

                var editCmd = new EditCellCommand() { Spreadsheet = ss, CellCoordinate = new Coordinate() { Name = "E11" } };
                editCmd.Value = 500;
                editCmd.Execute();

                var delColCmd = new DeleteColumnCommand() { Spreadsheet = ss, ColumnCoordinate = new Coordinate() { ColumnName = "B" } };
                delColCmd.Execute();

                var delRowCmd = new DeleteRowCommand() { Spreadsheet = ss, RowCoordinate = new Coordinate() { RowName = "2" } };
                delRowCmd.Execute();

                saveCmd.Execute();

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
