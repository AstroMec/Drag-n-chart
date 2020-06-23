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
    public partial class OtherHelp : UserControl
    {
        public OtherHelp()
        {
            InitializeComponent();
        }

        private void OtherHelp_Load(object sender, EventArgs e)
        {
            scrollZoomDescr.MaximumSize = new Size(this.Size.Width, 0);
            viewingCommentsDescr.MaximumSize = new Size(this.Size.Width, 0);
        }
    }
}
