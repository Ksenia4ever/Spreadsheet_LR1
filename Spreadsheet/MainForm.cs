using Commands;
using DataModel;

namespace SpreadsheetUI
{
    public partial class MainForm : Form
    {
        Spreadsheet Spreadsheet { get; set; } = new Spreadsheet() { Columns = 15, Rows = 15 };

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            Spreadsheet.AddCell(new Coordinate() { Name = "D10" }).Value = 50;
            Spreadsheet.AddCell(new Coordinate() { Name = "B1" }).Value = 30;
            Spreadsheet.AddCell(new Coordinate() { Name = "A1" }).Value = 10;
            Spreadsheet.AddCell(new Coordinate() { Name = "B2" }).Value = 40;
            Spreadsheet.AddCell(new Coordinate() { Name = "A2" }).Value = 20;

            UpdateGrid();
        }

        void UpdateGrid()
        {
            _grid.ColumnCount = Spreadsheet.Columns;
            _grid.RowCount = Spreadsheet.Rows;

            for (var col = 0; col < Spreadsheet.Columns; col++)
            {
                var coordinate = new Coordinate() { Column = col };
                _grid.Columns[col].HeaderText = coordinate.ColumnName;
            }

            _grid.Invalidate();
        }

        void OnRowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rowName = new Coordinate() { Row = e.RowIndex }.RowName;

            var bounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, _grid.RowHeadersWidth, e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics,
                                  rowName,
                                  _grid.RowHeadersDefaultCellStyle.Font,
                                  bounds,
                                  _grid.RowHeadersDefaultCellStyle.ForeColor,
                                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        void OnCellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            var coord = new Coordinate() { Column = e.ColumnIndex, Row = e.RowIndex };
            var cell = Spreadsheet.FindCell(coord);
            if (cell != null)
            {
                e.Value = cell.GetValue(Spreadsheet);
            }
            else
            {
                e.Value = string.Empty;
            }
        }

        void OnCellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {

        }

        void OnNewSpreadsheet(object sender, EventArgs e)
        {
            Spreadsheet = new Spreadsheet() { Columns = 15, Rows = 15 };
            UpdateGrid();
        }

        void OnLoadSpreadsheet(object sender, EventArgs e)
        {
            try
            {
                var res = _openFileDialog.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    var cmd = new LoadSpreadsheetCommand() { FilePath = _openFileDialog.FileName };
                    cmd.Execute();

                    Spreadsheet = cmd.Spreadsheet!;

                    UpdateGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OnSaveSpreadsheet(object sender, EventArgs e)
        {
            try
            {
                var res = _saveFileDialog.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    var cmd = new SaveSpreadsheetCommand() { Spreadsheet = Spreadsheet, FilePath = _saveFileDialog.FileName };
                    cmd.Execute();

                    UpdateGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OnAddColumn(object sender, EventArgs e)
        {
            try
            {
                var currentCell = _grid.CurrentCell;
                if (currentCell != null)
                {
                    var coordinate = new Coordinate() { Column = currentCell.ColumnIndex, Row = currentCell.RowIndex };
                    var cmd = new AddColumnCommand() { Spreadsheet = Spreadsheet, ColumnCoordinate = coordinate };
                    cmd.Execute();

                    UpdateGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OnDeleteColumn(object sender, EventArgs e)
        {
            try
            {
                var currentCell = _grid.CurrentCell;
                if (currentCell != null)
                {
                    var coordinate = new Coordinate() { Column = currentCell.ColumnIndex, Row = currentCell.RowIndex };
                    var cmd = new DeleteColumnCommand() { Spreadsheet = Spreadsheet, ColumnCoordinate = coordinate };
                    cmd.Execute();

                    UpdateGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OnAddRow(object sender, EventArgs e)
        {
            try
            {
                var currentCell = _grid.CurrentCell;
                if (currentCell != null)
                {
                    var coordinate = new Coordinate() { Column = currentCell.ColumnIndex, Row = currentCell.RowIndex };
                    var cmd = new AddRowCommand() { Spreadsheet = Spreadsheet, RowCoordinate = coordinate };
                    cmd.Execute();

                    UpdateGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDeleteRow(object sender, EventArgs e)
        {
            try
            {
                var currentCell = _grid.CurrentCell;
                if (currentCell != null)
                {
                    var coordinate = new Coordinate() { Column = currentCell.ColumnIndex, Row = currentCell.RowIndex };
                    var cmd = new DeleteRowCommand() { Spreadsheet = Spreadsheet, RowCoordinate = coordinate };
                    cmd.Execute();

                    UpdateGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OnClearCell(object sender, EventArgs e)
        {
            try
            {
                var currentCell = _grid.CurrentCell;
                if (currentCell != null)
                {
                    var coordinate = new Coordinate() { Column = currentCell.ColumnIndex, Row = currentCell.RowIndex };
                    var cmd = new ClearCellCommand() { Spreadsheet = Spreadsheet, CellCoordinate = coordinate };
                    cmd.Execute();

                    UpdateGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OnClearAllCells(object sender, EventArgs e)
        {
            try
            {
                var cmd = new ClearAllCellsCommand() { Spreadsheet = Spreadsheet };
                cmd.Execute();

                UpdateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
