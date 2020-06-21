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
    public partial class DataHelp : UserControl
    {
        public DataHelp()
        {
            InitializeComponent();
        }

        private void DataHelp_Load(object sender, EventArgs e)
        {
            importXlsxDescr.MaximumSize = new Size(this.Size.Width, 0);
            selectSheetDecr.MaximumSize = new Size(this.Size.Width, 0);
        }
    }
}
