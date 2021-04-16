
namespace KTDH
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.hasArrowCheckBox = new System.Windows.Forms.CheckBox();
            this.drawPanel = new System.Windows.Forms.Panel();
            this.lineStyleComboBox = new System.Windows.Forms.ComboBox();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.btDrawLine = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.LemonChiffon;
            this.mainPanel.Controls.Add(this.btnClear);
            this.mainPanel.Controls.Add(this.hasArrowCheckBox);
            this.mainPanel.Controls.Add(this.drawPanel);
            this.mainPanel.Controls.Add(this.lineStyleComboBox);
            this.mainPanel.Controls.Add(this.labelY);
            this.mainPanel.Controls.Add(this.labelX);
            this.mainPanel.Controls.Add(this.textBoxX);
            this.mainPanel.Controls.Add(this.textBoxY);
            this.mainPanel.Controls.Add(this.btDrawLine);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(811, 480);
            this.mainPanel.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(13, 42);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button1_Click);
            // 
            // hasArrowCheckBox
            // 
            this.hasArrowCheckBox.AutoSize = true;
            this.hasArrowCheckBox.Location = new System.Drawing.Point(12, 116);
            this.hasArrowCheckBox.Name = "hasArrowCheckBox";
            this.hasArrowCheckBox.Size = new System.Drawing.Size(81, 19);
            this.hasArrowCheckBox.TabIndex = 10;
            this.hasArrowCheckBox.Text = "Has Arrow";
            this.hasArrowCheckBox.UseVisualStyleBackColor = true;
            // 
            // drawPanel
            // 
            this.drawPanel.BackColor = System.Drawing.Color.White;
            this.drawPanel.Location = new System.Drawing.Point(112, 0);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(700, 480);
            this.drawPanel.TabIndex = 9;
            this.drawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseDown);
            this.drawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseMove);
            this.drawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseUp);
            // 
            // lineStyleComboBox
            // 
            this.lineStyleComboBox.FormattingEnabled = true;
            this.lineStyleComboBox.Items.AddRange(new object[] {
            "Basic Line",
            "Dash Line",
            "Dash 1 dot Line",
            "Dash 2 dot Line",
            "Rectangle",
            "Circle"});
            this.lineStyleComboBox.Location = new System.Drawing.Point(12, 87);
            this.lineStyleComboBox.Name = "lineStyleComboBox";
            this.lineStyleComboBox.Size = new System.Drawing.Size(75, 23);
            this.lineStyleComboBox.TabIndex = 8;
            this.lineStyleComboBox.Text = "Basic Line";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(12, 416);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 15);
            this.labelY.TabIndex = 7;
            this.labelY.Text = "Y";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.BackColor = System.Drawing.Color.Transparent;
            this.labelX.Location = new System.Drawing.Point(12, 384);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 15);
            this.labelX.TabIndex = 6;
            this.labelX.Text = "X";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(32, 381);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(55, 23);
            this.textBoxX.TabIndex = 5;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(32, 413);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(55, 23);
            this.textBoxY.TabIndex = 4;
            // 
            // btDrawLine
            // 
            this.btDrawLine.Location = new System.Drawing.Point(12, 12);
            this.btDrawLine.Name = "btDrawLine";
            this.btDrawLine.Size = new System.Drawing.Size(75, 23);
            this.btDrawLine.TabIndex = 0;
            this.btDrawLine.Text = "Draw";
            this.btDrawLine.UseVisualStyleBackColor = true;
            this.btDrawLine.Click += new System.EventHandler(this.btDrawLine_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 480);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btDrawLine;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.ComboBox lineStyleComboBox;
        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.CheckBox hasArrowCheckBox;
        private System.Windows.Forms.Button btnClear;
    }
}

