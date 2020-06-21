namespace Drag_n_chart.AppControls
{
    partial class ViewHelp
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
            this.chartElementsDescr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataLabelsDescr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chart elements";
            // 
            // chartElementsDescr
            // 
            this.chartElementsDescr.AutoSize = true;
            this.chartElementsDescr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartElementsDescr.Location = new System.Drawing.Point(3, 76);
            this.chartElementsDescr.MaximumSize = new System.Drawing.Size(626, 0);
            this.chartElementsDescr.Name = "chartElementsDescr";
            this.chartElementsDescr.Size = new System.Drawing.Size(598, 78);
            this.chartElementsDescr.TabIndex = 1;
            this.chartElementsDescr.Text = "Enabling and disabling these will show them on the chart or not.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 53);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data labels";
            // 
            // dataLabelsDescr
            // 
            this.dataLabelsDescr.AutoSize = true;
            this.dataLabelsDescr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataLabelsDescr.Location = new System.Drawing.Point(3, 224);
            this.dataLabelsDescr.MaximumSize = new System.Drawing.Size(626, 0);
            this.dataLabelsDescr.Name = "dataLabelsDescr";
            this.dataLabelsDescr.Size = new System.Drawing.Size(620, 78);
            this.dataLabelsDescr.TabIndex = 3;
            this.dataLabelsDescr.Text = "Enabling this will show what the actual data is for every point on the chart.";
            // 
            // ViewHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dataLabelsDescr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chartElementsDescr);
            this.Controls.Add(this.label1);
            this.Name = "ViewHelp";
            this.Size = new System.Drawing.Size(626, 368);
            this.Load += new System.EventHandler(this.ViewHelp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label chartElementsDescr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label dataLabelsDescr;
    }
}
