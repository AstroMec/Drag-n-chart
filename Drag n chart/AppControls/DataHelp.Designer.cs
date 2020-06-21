namespace Drag_n_chart.AppControls
{
    partial class DataHelp
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.importXlsxDescr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.selectSheetDecr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Importing excel file";
            // 
            // importXlsxDescr
            // 
            this.importXlsxDescr.AutoSize = true;
            this.importXlsxDescr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importXlsxDescr.Location = new System.Drawing.Point(3, 53);
            this.importXlsxDescr.MaximumSize = new System.Drawing.Size(764, 0);
            this.importXlsxDescr.Name = "importXlsxDescr";
            this.importXlsxDescr.Size = new System.Drawing.Size(757, 117);
            this.importXlsxDescr.TabIndex = 1;
            this.importXlsxDescr.Text = "This will load the excel file you want to visualise the data from. This can also " +
    "be done by draggin the file to the program.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 53);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select sheet";
            // 
            // selectSheetDecr
            // 
            this.selectSheetDecr.AutoSize = true;
            this.selectSheetDecr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectSheetDecr.Location = new System.Drawing.Point(3, 273);
            this.selectSheetDecr.MaximumSize = new System.Drawing.Size(764, 0);
            this.selectSheetDecr.Name = "selectSheetDecr";
            this.selectSheetDecr.Size = new System.Drawing.Size(753, 78);
            this.selectSheetDecr.TabIndex = 3;
            this.selectSheetDecr.Text = "This will allow you to chose which sheet to plot the data for.";
            // 
            // DataHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.selectSheetDecr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.importXlsxDescr);
            this.Controls.Add(this.label1);
            this.Name = "DataHelp";
            this.Size = new System.Drawing.Size(764, 439);
            this.Load += new System.EventHandler(this.DataHelp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label importXlsxDescr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label selectSheetDecr;
    }
}
