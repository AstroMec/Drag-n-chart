using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Drag_n_chart.Forms
{
    public partial class SelectSheet : Form
    {
        public static event EventHandler UpdateReadings;

        public Dictionary<string, int> ComboBoxItems { get; set; } = new Dictionary<string, int>();

        public SelectSheet()
        {
            InitializeComponent();
            GetSheetsList();
        }

        public void GetSheetsList()
        {
            try
            {
                
                foreach (Worksheet item in MainScreen.ExcelStream.Workbook.Worksheets)
                {
                    ComboBoxItems.Add(item.Name, item.Index);
                    sheetsList.Items.Add(item.Name);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No excel file has been selected!", "Data error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void sheetsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainScreen.SelectWorksheet(ComboBoxItems[(string)sheetsList.SelectedItem]);
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                this.Text += " - Loading data and chart...";
                UpdateReadings(sender, e);
                DialogResult = DialogResult.OK;
            }
        }

        private void sheetsList_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                if (DialogResult == DialogResult.Cancel)
                {
                    //Ignore.
                }
                else if (sheetsList.SelectedItem == null)
                {
                    throw new ApplicationException("You must select an item from the list.");
                }
                else if ((DialogResult != DialogResult.Cancel) && (string)sheetsList.SelectedItem == "Comments")
                {
                    throw new ApplicationException("This is not a valid sheet to select.");
                }
                else if ((DialogResult != DialogResult.Cancel) && (string)sheetsList.SelectedItem == "MECA Monitoring")
                {
                    throw new ApplicationException("Not supported yet.");
                }
            }
            catch (ApplicationException ex)
            {
                errorProvider.SetError(sheetsList, ex.Message);
                e.Cancel = true;
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
