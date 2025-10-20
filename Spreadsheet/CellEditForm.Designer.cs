namespace SpreadsheetUI
{
    partial class CellEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _valueLabel = new Label();
            _valueTextBox = new TextBox();
            _infoLabel = new Label();
            _okButton = new Button();
            _cancelButton = new Button();
            SuspendLayout();
            // 
            // _valueLabel
            // 
            _valueLabel.AutoSize = true;
            _valueLabel.Location = new Point(12, 15);
            _valueLabel.Name = "_valueLabel";
            _valueLabel.Size = new Size(35, 15);
            _valueLabel.TabIndex = 0;
            _valueLabel.Text = "Value";
            // 
            // _valueTextBox
            // 
            _valueTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _valueTextBox.Location = new Point(53, 12);
            _valueTextBox.Name = "_valueTextBox";
            _valueTextBox.Size = new Size(396, 23);
            _valueTextBox.TabIndex = 1;
            // 
            // _infoLabel
            // 
            _infoLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _infoLabel.Location = new Point(12, 52);
            _infoLabel.Name = "_infoLabel";
            _infoLabel.Size = new Size(437, 49);
            _infoLabel.TabIndex = 2;
            _infoLabel.Text = "If you want to input formulat insteda of value, please start intput from symbol '='. For example \"= A1 + 10\"";
            // 
            // _okButton
            // 
            _okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _okButton.Location = new Point(293, 104);
            _okButton.Name = "_okButton";
            _okButton.Size = new Size(75, 23);
            _okButton.TabIndex = 3;
            _okButton.Text = "OK";
            _okButton.UseVisualStyleBackColor = true;
            _okButton.Click += OnOK;
            // 
            // _cancelButton
            // 
            _cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _cancelButton.Location = new Point(374, 104);
            _cancelButton.Name = "_cancelButton";
            _cancelButton.Size = new Size(75, 23);
            _cancelButton.TabIndex = 3;
            _cancelButton.Text = "Cancel";
            _cancelButton.UseVisualStyleBackColor = true;
            // 
            // CellEditForm
            // 
            AcceptButton = _okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _cancelButton;
            ClientSize = new Size(461, 139);
            Controls.Add(_cancelButton);
            Controls.Add(_okButton);
            Controls.Add(_infoLabel);
            Controls.Add(_valueTextBox);
            Controls.Add(_valueLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "CellEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cell Value";
            Load += OnLoad;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label _valueLabel;
        private TextBox _valueTextBox;
        private Label _infoLabel;
        private Button _okButton;
        private Button _cancelButton;
    }
}