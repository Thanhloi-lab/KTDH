
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbDegree = new System.Windows.Forms.TextBox();
            this.btTransform = new System.Windows.Forms.Button();
            this.valueYLabel = new System.Windows.Forms.Label();
            this.valueYTextBox = new System.Windows.Forms.TextBox();
            this.valueXLabel = new System.Windows.Forms.Label();
            this.valueXTextBox = new System.Windows.Forms.TextBox();
            this.transformationComboBox = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.hasArrowCheckBox = new System.Windows.Forms.CheckBox();
            this.drawPanel = new System.Windows.Forms.Panel();
            this.lineStyleComboBox = new System.Windows.Forms.ComboBox();
            this.btDrawLine = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.LemonChiffon;
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.tbDegree);
            this.mainPanel.Controls.Add(this.btTransform);
            this.mainPanel.Controls.Add(this.valueYLabel);
            this.mainPanel.Controls.Add(this.valueYTextBox);
            this.mainPanel.Controls.Add(this.valueXLabel);
            this.mainPanel.Controls.Add(this.valueXTextBox);
            this.mainPanel.Controls.Add(this.transformationComboBox);
            this.mainPanel.Controls.Add(this.btnClear);
            this.mainPanel.Controls.Add(this.hasArrowCheckBox);
            this.mainPanel.Controls.Add(this.drawPanel);
            this.mainPanel.Controls.Add(this.lineStyleComboBox);
            this.mainPanel.Controls.Add(this.btDrawLine);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(811, 480);
            this.mainPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Degree";
            // 
            // tbDegree
            // 
            this.tbDegree.Location = new System.Drawing.Point(59, 307);
            this.tbDegree.MaxLength = 5;
            this.tbDegree.Name = "tbDegree";
            this.tbDegree.Size = new System.Drawing.Size(34, 23);
            this.tbDegree.TabIndex = 18;
            this.tbDegree.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDegree_KeyPress);
            // 
            // btTransform
            // 
            this.btTransform.Location = new System.Drawing.Point(11, 278);
            this.btTransform.Name = "btTransform";
            this.btTransform.Size = new System.Drawing.Size(75, 23);
            this.btTransform.TabIndex = 17;
            this.btTransform.Text = "Transform";
            this.btTransform.UseVisualStyleBackColor = true;
            this.btTransform.Click += new System.EventHandler(this.btTransform_Click);
            // 
            // valueYLabel
            // 
            this.valueYLabel.AutoSize = true;
            this.valueYLabel.Location = new System.Drawing.Point(11, 247);
            this.valueYLabel.Name = "valueYLabel";
            this.valueYLabel.Size = new System.Drawing.Size(42, 15);
            this.valueYLabel.TabIndex = 16;
            this.valueYLabel.Text = "ValueY";
            // 
            // valueYTextBox
            // 
            this.valueYTextBox.Location = new System.Drawing.Point(59, 244);
            this.valueYTextBox.MaxLength = 5;
            this.valueYTextBox.Name = "valueYTextBox";
            this.valueYTextBox.Size = new System.Drawing.Size(34, 23);
            this.valueYTextBox.TabIndex = 15;
            this.valueYTextBox.Text = "2";
            this.valueYTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valueYTextBox_KeyPress);
            // 
            // valueXLabel
            // 
            this.valueXLabel.AutoSize = true;
            this.valueXLabel.Location = new System.Drawing.Point(11, 218);
            this.valueXLabel.Name = "valueXLabel";
            this.valueXLabel.Size = new System.Drawing.Size(42, 15);
            this.valueXLabel.TabIndex = 14;
            this.valueXLabel.Text = "ValueX";
            // 
            // valueXTextBox
            // 
            this.valueXTextBox.Location = new System.Drawing.Point(59, 215);
            this.valueXTextBox.MaxLength = 5;
            this.valueXTextBox.Name = "valueXTextBox";
            this.valueXTextBox.Size = new System.Drawing.Size(34, 23);
            this.valueXTextBox.TabIndex = 13;
            this.valueXTextBox.Text = "2";
            this.valueXTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // transformationComboBox
            // 
            this.transformationComboBox.Enabled = false;
            this.transformationComboBox.FormattingEnabled = true;
            this.transformationComboBox.Items.AddRange(new object[] {
            "Default",
            "Move To",
            "Rotate To",
            "Flip X",
            "Flip Y",
            "Flip O"});
            this.transformationComboBox.Location = new System.Drawing.Point(12, 173);
            this.transformationComboBox.Name = "transformationComboBox";
            this.transformationComboBox.Size = new System.Drawing.Size(75, 23);
            this.transformationComboBox.TabIndex = 12;
            this.transformationComboBox.Text = "Default";
            this.transformationComboBox.SelectedIndexChanged += new System.EventHandler(this.TransformationComboBox_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(13, 42);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            "Circle",
            "Ellipse"});
            this.lineStyleComboBox.Location = new System.Drawing.Point(12, 87);
            this.lineStyleComboBox.Name = "lineStyleComboBox";
            this.lineStyleComboBox.Size = new System.Drawing.Size(75, 23);
            this.lineStyleComboBox.TabIndex = 8;
            this.lineStyleComboBox.Text = "Basic Line";
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
        private System.Windows.Forms.ComboBox lineStyleComboBox;
        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.CheckBox hasArrowCheckBox;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox transformationComboBox;
        private System.Windows.Forms.Label valueXLabel;
        private System.Windows.Forms.TextBox valueXTextBox;
        private System.Windows.Forms.Label valueYLabel;
        private System.Windows.Forms.TextBox valueYTextBox;
        private System.Windows.Forms.Button btTransform;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDegree;
    }
}

