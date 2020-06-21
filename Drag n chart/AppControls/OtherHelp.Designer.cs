namespace Drag_n_chart.AppControls
{
    partial class OtherHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OtherHelp));
            this.label1 = new System.Windows.Forms.Label();
            this.scrollZoomDescr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(640, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scrolling and zooming on the chart";
            // 
            // scrollZoomDescr
            // 
            this.scrollZoomDescr.AutoSize = true;
            this.scrollZoomDescr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrollZoomDescr.Location = new System.Drawing.Point(3, 57);
            this.scrollZoomDescr.MaximumSize = new System.Drawing.Size(759, 0);
            this.scrollZoomDescr.Name = "scrollZoomDescr";
            this.scrollZoomDescr.Size = new System.Drawing.Size(753, 234);
            this.scrollZoomDescr.TabIndex = 1;
            this.scrollZoomDescr.Text = resources.GetString("scrollZoomDescr.Text");
            // 
            // OtherHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.scrollZoomDescr);
            this.Controls.Add(this.label1);
            this.Name = "OtherHelp";
            this.Size = new System.Drawing.Size(765, 844);
            this.Load += new System.EventHandler(this.OtherHelp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label scrollZoomDescr;
    }
}
