
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
            this.btDrawMyCoordinate = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.btDrawArrow = new System.Windows.Forms.Button();
            this.btDrawDashLineWithTwoDot = new System.Windows.Forms.Button();
            this.btDrawDashLineWithOneDot = new System.Windows.Forms.Button();
            this.btDrawDashLine = new System.Windows.Forms.Button();
            this.btDrawRecangle = new System.Windows.Forms.Button();
            this.btDrawLine = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.btDrawMyCoordinate);
            this.mainPanel.Controls.Add(this.btClear);
            this.mainPanel.Controls.Add(this.btDrawArrow);
            this.mainPanel.Controls.Add(this.btDrawDashLineWithTwoDot);
            this.mainPanel.Controls.Add(this.btDrawDashLineWithOneDot);
            this.mainPanel.Controls.Add(this.btDrawDashLine);
            this.mainPanel.Controls.Add(this.btDrawRecangle);
            this.mainPanel.Controls.Add(this.btDrawLine);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(938, 450);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseDown);
            this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
            this.mainPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseUp);
            // 
            // btDrawMyCoordinate
            // 
            this.btDrawMyCoordinate.Location = new System.Drawing.Point(817, 203);
            this.btDrawMyCoordinate.Name = "btDrawMyCoordinate";
            this.btDrawMyCoordinate.Size = new System.Drawing.Size(121, 23);
            this.btDrawMyCoordinate.TabIndex = 7;
            this.btDrawMyCoordinate.Text = "Draw MyCoordinate";
            this.btDrawMyCoordinate.UseVisualStyleBackColor = true;
            this.btDrawMyCoordinate.Click += new System.EventHandler(this.btDrawMyCoordinate_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(817, 174);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(121, 23);
            this.btClear.TabIndex = 6;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btDrawArrow
            // 
            this.btDrawArrow.Location = new System.Drawing.Point(817, 145);
            this.btDrawArrow.Name = "btDrawArrow";
            this.btDrawArrow.Size = new System.Drawing.Size(121, 23);
            this.btDrawArrow.TabIndex = 5;
            this.btDrawArrow.Text = "Draw arrow";
            this.btDrawArrow.UseVisualStyleBackColor = true;
            this.btDrawArrow.Click += new System.EventHandler(this.btDrawArrow_Click);
            // 
            // btDrawDashLineWithTwoDot
            // 
            this.btDrawDashLineWithTwoDot.Location = new System.Drawing.Point(817, 87);
            this.btDrawDashLineWithTwoDot.Name = "btDrawDashLineWithTwoDot";
            this.btDrawDashLineWithTwoDot.Size = new System.Drawing.Size(121, 23);
            this.btDrawDashLineWithTwoDot.TabIndex = 4;
            this.btDrawDashLineWithTwoDot.Text = "Draw dashline 2 dot";
            this.btDrawDashLineWithTwoDot.UseVisualStyleBackColor = true;
            this.btDrawDashLineWithTwoDot.Click += new System.EventHandler(this.btDrawDashLineWithTwoDot_Click);
            // 
            // btDrawDashLineWithOneDot
            // 
            this.btDrawDashLineWithOneDot.Location = new System.Drawing.Point(817, 58);
            this.btDrawDashLineWithOneDot.Name = "btDrawDashLineWithOneDot";
            this.btDrawDashLineWithOneDot.Size = new System.Drawing.Size(121, 23);
            this.btDrawDashLineWithOneDot.TabIndex = 3;
            this.btDrawDashLineWithOneDot.Text = "Draw dashline 1 dot";
            this.btDrawDashLineWithOneDot.UseVisualStyleBackColor = true;
            this.btDrawDashLineWithOneDot.Click += new System.EventHandler(this.btDrawDashLineWithOneDot_Click);
            // 
            // btDrawDashLine
            // 
            this.btDrawDashLine.Location = new System.Drawing.Point(817, 29);
            this.btDrawDashLine.Name = "btDrawDashLine";
            this.btDrawDashLine.Size = new System.Drawing.Size(121, 23);
            this.btDrawDashLine.TabIndex = 2;
            this.btDrawDashLine.Text = "Draw dashline";
            this.btDrawDashLine.UseVisualStyleBackColor = true;
            this.btDrawDashLine.Click += new System.EventHandler(this.btDrawDashLine_Click);
            // 
            // btDrawRecangle
            // 
            this.btDrawRecangle.Location = new System.Drawing.Point(817, 116);
            this.btDrawRecangle.Name = "btDrawRecangle";
            this.btDrawRecangle.Size = new System.Drawing.Size(121, 23);
            this.btDrawRecangle.TabIndex = 1;
            this.btDrawRecangle.Text = "Draw Recangle";
            this.btDrawRecangle.UseVisualStyleBackColor = true;
            this.btDrawRecangle.Click += new System.EventHandler(this.drawRecangle_Click);
            // 
            // btDrawLine
            // 
            this.btDrawLine.Location = new System.Drawing.Point(817, 0);
            this.btDrawLine.Name = "btDrawLine";
            this.btDrawLine.Size = new System.Drawing.Size(121, 23);
            this.btDrawLine.TabIndex = 0;
            this.btDrawLine.Text = "Draw line";
            this.btDrawLine.UseVisualStyleBackColor = true;
            this.btDrawLine.Click += new System.EventHandler(this.btDrawLine_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 450);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btDrawLine;
        private System.Windows.Forms.Button btDrawDashLineWithTwoDot;
        private System.Windows.Forms.Button btDrawDashLineWithOneDot;
        private System.Windows.Forms.Button btDrawDashLine;
        private System.Windows.Forms.Button btDrawRecangle;
        private System.Windows.Forms.Button btDrawArrow;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btDrawMyCoordinate;
    }
}

