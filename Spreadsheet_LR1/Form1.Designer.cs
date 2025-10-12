namespace Spreadsheet_LR1
{
    partial class Form1
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
            formulaTextBox = new TextBox();
            calcualteButton = new Button();
            resultTextBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // formulaTextBox
            // 
            formulaTextBox.Location = new Point(33, 39);
            formulaTextBox.Name = "formulaTextBox";
            formulaTextBox.Size = new Size(426, 23);
            formulaTextBox.TabIndex = 0;
            // 
            // calcualteButton
            // 
            calcualteButton.Location = new Point(486, 39);
            calcualteButton.Name = "calcualteButton";
            calcualteButton.Size = new Size(75, 23);
            calcualteButton.TabIndex = 1;
            calcualteButton.Text = "Calculate";
            calcualteButton.UseVisualStyleBackColor = true;
            calcualteButton.Click += OnCalculateClick;
            // 
            // resultTextBox
            // 
            resultTextBox.Location = new Point(81, 68);
            resultTextBox.Name = "resultTextBox";
            resultTextBox.Size = new Size(378, 23);
            resultTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 72);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 3;
            label1.Text = "Result:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 135);
            Controls.Add(label1);
            Controls.Add(resultTextBox);
            Controls.Add(calcualteButton);
            Controls.Add(formulaTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox formulaTextBox;
        private Button calcualteButton;
        private TextBox resultTextBox;
        private Label label1;
    }
}
