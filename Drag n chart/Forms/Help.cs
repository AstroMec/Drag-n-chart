using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Drag_n_chart.AppControls;

namespace Drag_n_chart.Forms
{
    public partial class Help : Form
    {
        private Dictionary<string, HelpTypes> HelpMap { get; set; } = new Dictionary<string, HelpTypes>();

        public Help()
        {
            InitializeComponent();
            HelpMap.Add("File", HelpTypes.File);
            HelpMap.Add("View", HelpTypes.View);
            HelpMap.Add("Data", HelpTypes.Data);
            HelpMap.Add("Other parts of the program", HelpTypes.Other);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SplitterPanel panel = splitContainer.Panel2;
            panel.Controls.Clear();

            try
            {
                switch (HelpMap[treeView.SelectedNode.Text]) //This will get the corresponding enum.
                {
                    case HelpTypes.File:
                        panel.Controls.Add(new FileHelp() { Dock = DockStyle.Fill });
                        break;

                    case HelpTypes.View:
                        panel.Controls.Add(new ViewHelp() { Dock = DockStyle.Fill });
                        break;

                    case HelpTypes.Data:
                        panel.Controls.Add(new DataHelp() { Dock = DockStyle.Fill });
                        break;

                    default:
                        panel.Controls.Add(new OtherHelp() { Dock = DockStyle.Fill });
                        break;
                }
            }
            catch
            {
                //If the roots are selected, there's going to be an error that is thrown.
            }
        }

        /// <summary>
        /// This enum makes it easier to read my code.
        /// </summary>
        private enum HelpTypes
        {
            File,
            View,
            Data,
            Other
        }
    }
}
