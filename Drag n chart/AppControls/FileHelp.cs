using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drag_n_chart.AppControls
{
    public partial class FileHelp : UserControl
    {
        public FileHelp()
        {
            InitializeComponent();
        }

        private void FileHelp_Load(object sender, EventArgs e)
        {
            openProjDescr.MaximumSize = new Size(this.Size.Width, 0);
            savePorjDescr.MaximumSize = new Size(this.Size.Width, 0);
            exportDescr.MaximumSize = new Size(this.Size.Width, 0);
        }
    }
}
