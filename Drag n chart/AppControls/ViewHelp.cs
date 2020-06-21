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
    public partial class ViewHelp : UserControl
    {
        public ViewHelp()
        {
            InitializeComponent();
        }

        private void ViewHelp_Load(object sender, EventArgs e)
        {
            chartElementsDescr.MaximumSize = new Size(this.Size.Width, 0);
            dataLabelsDescr.MaximumSize = new Size(this.Size.Width, 0);
        }
    }
}
