namespace Drag_n_chart.AppControls
{
    partial class FileHelp
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
            this.openProjDescr = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.savePorjDescr = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.exportDescr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Open project";
            // 
            // openProjDescr
            // 
            this.openProjDescr.AutoSize = true;
            this.openProjDescr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openProjDescr.Location = new System.Drawing.Point(3, 53);
            this.openProjDescr.MaximumSize = new System.Drawing.Size(945, 0);
            this.openProjDescr.Name = "openProjDescr";
            this.openProjDescr.Size = new System.Drawing.Size(930, 78);
            this.openProjDescr.TabIndex = 1;
            this.openProjDescr.Text = "This allows to open a project where a project contains the path of the excel file" +
    " and the data is already loaded in the program.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 53);
            this.label2.TabIndex = 2;
            this.label2.Text = "Save project";
            // 
            // savePorjDescr
            // 
            this.savePorjDescr.AutoSize = true;
            this.savePorjDescr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePorjDescr.Location = new System.Drawing.Point(3, 208);
            this.savePorjDescr.MaximumSize = new System.Drawing.Size(945, 0);
            this.savePorjDescr.Name = "savePorjDescr";
            this.savePorjDescr.Size = new System.Drawing.Size(935, 78);
            this.savePorjDescr.TabIndex = 3;
            this.savePorjDescr.Text = "This allows to save the project, where the project contains the path of the excel" +
    " file and the data will already be loaded to the program.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(307, 53);
            this.label4.TabIndex = 4;
            this.label4.Text = "Export to image";
            // 
            // exportDescr
            // 
            this.exportDescr.AutoSize = true;
            this.exportDescr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportDescr.Location = new System.Drawing.Point(3, 369);
            this.exportDescr.MaximumSize = new System.Drawing.Size(945, 0);
            this.exportDescr.Name = "exportDescr";
            this.exportDescr.Size = new System.Drawing.Size(943, 78);
            this.exportDescr.TabIndex = 5;
            this.exportDescr.Text = "This will export the chart to an image. It will export it exactly as you can see " +
    "it now (even with the zoom and scroll configuration).";
            // 
            // FileHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.exportDescr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.savePorjDescr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.openProjDescr);
            this.Controls.Add(this.label1);
            this.Name = "FileHelp";
            this.Size = new System.Drawing.Size(945, 544);
            this.Load += new System.EventHandler(this.FileHelp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label openProjDescr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label savePorjDescr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label exportDescr;
    }
}
