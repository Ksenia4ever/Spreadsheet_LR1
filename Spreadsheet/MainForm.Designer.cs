namespace SpreadsheetUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            _grid = new DataGridView();
            _mainMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            columnToolStripMenuItem = new ToolStripMenuItem();
            addNToolStripMenuItem = new ToolStripMenuItem();
            deleteColumnToolStripMenuItem = new ToolStripMenuItem();
            rowToolStripMenuItem = new ToolStripMenuItem();
            addNewRowToolStripMenuItem = new ToolStripMenuItem();
            deleteRowToolStripMenuItem = new ToolStripMenuItem();
            cellToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            clearAllToolStripMenuItem = new ToolStripMenuItem();
            _openFileDialog = new OpenFileDialog();
            _saveFileDialog = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
            _mainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // _grid
            // 
            _grid.AllowUserToAddRows = false;
            _grid.AllowUserToDeleteRows = false;
            _grid.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            _grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            _grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            _grid.DefaultCellStyle = dataGridViewCellStyle2;
            _grid.Dock = DockStyle.Fill;
            _grid.Location = new Point(0, 24);
            _grid.MultiSelect = false;
            _grid.Name = "_grid";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            _grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            _grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            _grid.Size = new Size(800, 426);
            _grid.TabIndex = 0;
            _grid.VirtualMode = true;
            _grid.CellValueNeeded += OnCellValueNeeded;
            _grid.CellValuePushed += OnCellValuePushed;
            _grid.RowPostPaint += OnRowPostPaint;
            // 
            // _mainMenu
            // 
            _mainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, columnToolStripMenuItem, rowToolStripMenuItem, cellToolStripMenuItem });
            _mainMenu.Location = new Point(0, 0);
            _mainMenu.Name = "_mainMenu";
            _mainMenu.Size = new Size(800, 24);
            _mainMenu.TabIndex = 1;
            _mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, loadToolStripMenuItem, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(100, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += OnNewSpreadsheet;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(100, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += OnLoadSpreadsheet;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(100, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += OnSaveSpreadsheet;
            // 
            // columnToolStripMenuItem
            // 
            columnToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addNToolStripMenuItem, deleteColumnToolStripMenuItem });
            columnToolStripMenuItem.Name = "columnToolStripMenuItem";
            columnToolStripMenuItem.Size = new Size(62, 20);
            columnToolStripMenuItem.Text = "Column";
            // 
            // addNToolStripMenuItem
            // 
            addNToolStripMenuItem.Name = "addNToolStripMenuItem";
            addNToolStripMenuItem.Size = new Size(165, 22);
            addNToolStripMenuItem.Text = "Add new column";
            addNToolStripMenuItem.Click += OnAddColumn;
            // 
            // deleteColumnToolStripMenuItem
            // 
            deleteColumnToolStripMenuItem.Name = "deleteColumnToolStripMenuItem";
            deleteColumnToolStripMenuItem.Size = new Size(165, 22);
            deleteColumnToolStripMenuItem.Text = "Delete column";
            deleteColumnToolStripMenuItem.Click += OnDeleteColumn;
            // 
            // rowToolStripMenuItem
            // 
            rowToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addNewRowToolStripMenuItem, deleteRowToolStripMenuItem });
            rowToolStripMenuItem.Name = "rowToolStripMenuItem";
            rowToolStripMenuItem.Size = new Size(42, 20);
            rowToolStripMenuItem.Text = "Row";
            // 
            // addNewRowToolStripMenuItem
            // 
            addNewRowToolStripMenuItem.Name = "addNewRowToolStripMenuItem";
            addNewRowToolStripMenuItem.Size = new Size(144, 22);
            addNewRowToolStripMenuItem.Text = "Add new row";
            addNewRowToolStripMenuItem.Click += OnAddRow;
            // 
            // deleteRowToolStripMenuItem
            // 
            deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            deleteRowToolStripMenuItem.Size = new Size(144, 22);
            deleteRowToolStripMenuItem.Text = "Delete row";
            deleteRowToolStripMenuItem.Click += OnDeleteRow;
            // 
            // cellToolStripMenuItem
            // 
            cellToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clearToolStripMenuItem, clearAllToolStripMenuItem });
            cellToolStripMenuItem.Name = "cellToolStripMenuItem";
            cellToolStripMenuItem.Size = new Size(39, 20);
            cellToolStripMenuItem.Text = "Cell";
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(116, 22);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += OnClearCell;
            // 
            // clearAllToolStripMenuItem
            // 
            clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            clearAllToolStripMenuItem.Size = new Size(116, 22);
            clearAllToolStripMenuItem.Text = "Clear all";
            clearAllToolStripMenuItem.Click += OnClearAllCells;
            // 
            // _openFileDialog
            // 
            _openFileDialog.DefaultExt = "json";
            _openFileDialog.FileName = "Spreadsheet.json";
            _openFileDialog.Filter = "JSON files|*.json";
            _openFileDialog.Title = "Open Spreadsheet";
            // 
            // _saveFileDialog
            // 
            _saveFileDialog.DefaultExt = "json";
            _saveFileDialog.FileName = "Spreadsheet.json";
            _saveFileDialog.Filter = "JSON files|*.json";
            _saveFileDialog.Title = "Save Spreadsheet";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(_grid);
            Controls.Add(_mainMenu);
            MainMenuStrip = _mainMenu;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Spreadsheet";
            ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
            _mainMenu.ResumeLayout(false);
            _mainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView _grid;
        private MenuStrip _mainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem columnToolStripMenuItem;
        private ToolStripMenuItem rowToolStripMenuItem;
        private ToolStripMenuItem addNToolStripMenuItem;
        private ToolStripMenuItem deleteColumnToolStripMenuItem;
        private ToolStripMenuItem addNewRowToolStripMenuItem;
        private ToolStripMenuItem deleteRowToolStripMenuItem;
        private OpenFileDialog _openFileDialog;
        private SaveFileDialog _saveFileDialog;
        private ToolStripMenuItem cellToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem clearAllToolStripMenuItem;
    }
}
