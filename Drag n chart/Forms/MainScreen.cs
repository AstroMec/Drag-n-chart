using Drag_n_chart_core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Input = System.Windows.Input;

namespace Drag_n_chart.Forms
{
    public partial class MainScreen : Form
    {
        //todo select all.
        //todo 2 scales
        //todo comments
        //todo Make clear which sheet is selected.
        /// <summary>
        /// This property can be exported as a project.
        /// </summary>
        public static Project WorkingProject { get; set; } = new Project();

        /// <summary>
        /// This is effectively just a pointer or reference.
        /// </summary>
        public static ExcelStream ExcelStream { get => WorkingProject.ExcelStream; }

        /// <summary>
        /// This property allows the loading time to be reduced.
        /// </summary>
        public bool IsChartEmpty { get; set; } = true;

        public MainScreen()
        {
            InitializeComponent();
            SelectSheet.UpdateReadings += OnUpdateReadings;
            mainChart.MouseWheel += MainChart_MouseWheel;

            if (Program.MainArgs != null)
            {
                this.Show(); //Becuase this function is supposed to run, but however, since I'm
                //running porcedures before this ever runs, I have to run it before.

                if (!new string[] { ".xml", ".dncproj" }.Contains(Path.GetExtension(Program.MainArgs[0])))
                {
                    //When a file is dragged onto the program, it will launch the program with args.
                    //In the main program class, I encapsulate those args.
                    LoadExcelFile(Program.MainArgs[0]);
                    LoadChart(); 
                }
                else
                {
                    WorkingProject = new Project(Program.MainArgs[0]);

                    if (WorkingProject.ReadingsData != null)
                    {
                        LoadChart();
                    }
                }
            }
        }

        /// <summary>
        /// This will cause the chart to either zoom, or scroll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainChart_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Input.Keyboard.IsKeyDown(Input.Key.LeftCtrl))
            {
                //Zoom
                var xAxis = mainChart.ChartAreas[0].AxisX;
                var yAxis = mainChart.ChartAreas[0].AxisY;

                try
                {
                    if (e.Delta < 0) // Scrolled down.
                    {
                        xAxis.ScaleView.ZoomReset();
                        yAxis.ScaleView.ZoomReset();
                    }
                    else if (e.Delta > 0) // Scrolled up.
                    {
                        var xMin = xAxis.ScaleView.ViewMinimum;
                        var xMax = xAxis.ScaleView.ViewMaximum;
                        var yMin = yAxis.ScaleView.ViewMinimum;
                        var yMax = yAxis.ScaleView.ViewMaximum;

                        var posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                        var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                        var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                        var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                        xAxis.ScaleView.Zoom(posXStart, posXFinish);
                        yAxis.ScaleView.Zoom(posYStart, posYFinish);
                    }
                }
                catch
                {
                }
            }
            else if (Input.Keyboard.IsKeyDown(Input.Key.LeftAlt))
            {
                //Horizontal scroll
                try
                {
                    var xAxis = mainChart.ChartAreas[0].AxisX;

                    xAxis.ScaleView.Scroll(xAxis.ScaleView.Position + (e.Delta / 8));
                }
                catch
                {
                }
            }
            else
            {
                //Normal scroll
                try
                {
                    var yAxis = mainChart.ChartAreas[0].AxisY;

                    yAxis.ScaleView.Scroll(yAxis.ScaleView.Position + (e.Delta / 4));
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// This will clear the chart and it will then fill the chart with the data. 
        /// </summary>
        public void LoadChart()
        {
            this.Text += " - Loading chart...";

            if (!IsChartEmpty)
                //It will use as many threads and CPU cores as possible.
                Parallel.ForEach(mainChart.Series, series => this.Invoke((MethodInvoker)(() => series.Points.Clear())));

            foreach (var dataPoint in ((Readings)WorkingProject.ReadingsData).DataItems)
            {
                //Sometimes, if there is a null value, it can throw an error. 
                try { mainChart.Series["pH"].Points.AddXY(dataPoint.Date, dataPoint.pH); } catch { };
                try { mainChart.Series["Eh (mV)"].Points.AddXY(dataPoint.Date, dataPoint.Eh); } catch { };
                try { mainChart.Series["Density (g/ml)"].Points.AddXY(dataPoint.Date, dataPoint.Density); } catch { };
                try { mainChart.Series["DO (mg/l)"].Points.AddXY(dataPoint.Date, dataPoint.DO); } catch { };
                try { mainChart.Series["T-atm (°C)"].Points.AddXY(dataPoint.Date, dataPoint.T_atm); } catch { };
                try { mainChart.Series["T-Wat (°C)"].Points.AddXY(dataPoint.Date, dataPoint.T_wat); } catch { };
                try { mainChart.Series["Ag (ppm)"].Points.AddXY(dataPoint.Date, dataPoint.Ag); } catch { };
                try { mainChart.Series["Au (ppm)"].Points.AddXY(dataPoint.Date, dataPoint.Au); } catch { };
                try { mainChart.Series["Cl- (ppm)"].Points.AddXY(dataPoint.Date, dataPoint.Cl_minus); } catch { };
                try { mainChart.Series["Cl2 (ppm)"].Points.AddXY(dataPoint.Date, dataPoint.Cl2); } catch { };
                try { mainChart.Series["Co (ppm)"].Points.AddXY(dataPoint.Date, dataPoint.Co); } catch { };
                try { mainChart.Series["Cu (ppm)"].Points.AddXY(dataPoint.Date, dataPoint.Cu); } catch { };
                try { mainChart.Series["Ni (ppm)"].Points.AddXY(dataPoint.Date, dataPoint.Ni); } catch { };
                try { mainChart.Series["Fe (ppm)"].Points.AddXY(dataPoint.Date, dataPoint.Fe); } catch { };
                try { mainChart.Series["SO4 (2- ions) (ppm)"].Points.AddXY(dataPoint.Date, dataPoint.SO4_2minus); } catch { };
            }

            this.Text = "Drag n chart";

            IsChartEmpty = false;

        }

        /// <summary>
        /// This allows the excel file to be loaded into the program.
        /// </summary>
        /// <param name="path"></param>
        private void LoadExcelFile(string path)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                WorkingProject.ExcelStream = new ExcelStream(path);
                var window = new SelectSheet();
                window.BringToFront();
                window.ShowDialog();
                Cursor = Cursors.Default;
            }
            catch (ApplicationException ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error while opening file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString(), "External error occured.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This event will trigger the loading of the excel data and 
        /// will reload the chart.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUpdateReadings(object sender, EventArgs e)
        {
            try
            {
                WorkingProject.ReadingsData = WorkingProject.ExcelStream.GetAllSheetData();
                LoadChart();
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Error during loading of data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during loading of data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This will select the Worksheet.
        /// </summary>
        /// <param name="sheetIndex"></param>
        public static void SelectWorksheet(int sheetIndex)
        {
            WorkingProject.ExcelStream.Select(sheetIndex);
        }
        
        private void sheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new SelectSheet().ShowDialog();
            }
            catch (ObjectDisposedException)
            {
                //Sometimes, when an error occurs in the other screen, it throws an error in this
                //main screen and that's why I need to catch that error.
            }
        }

        private void MainScreen_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            LoadExcelFile(files[0]);
        }



        private void MainScreen_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void CheckRange()
        {
            mainChart.ResetAutoValues();
        }

        #region View
        private void pHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pHToolStripMenuItem.Checked = !pHToolStripMenuItem.Checked;

            if (pHToolStripMenuItem.Checked)
            {
                mainChart.Series["pH"].Enabled = true;
            }
            else
            {
                mainChart.Series["pH"].Enabled = false;
            }
            CheckRange();
        }

        private void ehToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ehToolStripMenuItem.Checked = !ehToolStripMenuItem.Checked;

            if (ehToolStripMenuItem.Checked)
            {
                mainChart.Series["Eh (mV)"].Enabled = true;
            }
            else
            {
                mainChart.Series["Eh (mV)"].Enabled = false;
            }
            CheckRange();
        }

        private void densityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            densityToolStripMenuItem.Checked = !densityToolStripMenuItem.Checked;

            if (densityToolStripMenuItem.Checked)
            {
                mainChart.Series["Density (g/ml)"].Enabled = true;
            }
            else
            {
                mainChart.Series["Density (g/ml)"].Enabled = false;
            }
            CheckRange();
        }

        private void dOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dOToolStripMenuItem.Checked = !dOToolStripMenuItem.Checked;

            if (dOToolStripMenuItem.Checked)
            {
                mainChart.Series["DO (mg/l)"].Enabled = true;
            }
            else
            {
                mainChart.Series["DO (mg/l)"].Enabled = false;
            }
            CheckRange();
        }

        private void tatmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tatmToolStripMenuItem.Checked = !tatmToolStripMenuItem.Checked;

            if (tatmToolStripMenuItem.Checked)
            {
                mainChart.Series["T-atm (°C)"].Enabled = true;
            }
            else
            {
                mainChart.Series["T-atm (°C)"].Enabled = false;
            }
            CheckRange();
        }

        private void twatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            twatToolStripMenuItem.Checked = !twatToolStripMenuItem.Checked;

            if (twatToolStripMenuItem.Checked)
            {
                mainChart.Series["T-Wat (°C)"].Enabled = true;
            }
            else
            {
                mainChart.Series["T-Wat (°C)"].Enabled = false;
            }
            CheckRange();
        }

        private void agToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agToolStripMenuItem.Checked = !agToolStripMenuItem.Checked;

            if (agToolStripMenuItem.Checked)
            {
                mainChart.Series["Ag (ppm)"].Enabled = true;
            }
            else
            {
                mainChart.Series["Ag (ppm)"].Enabled = false;
            }
            CheckRange();
        }

        private void auToolStripMenuItem_Click(object sender, EventArgs e)
        {
            auToolStripMenuItem.Checked = !auToolStripMenuItem.Checked;

            if (auToolStripMenuItem.Checked)
            {
                mainChart.Series["Au (ppm)"].Enabled = true;
            }
            else
            {
                mainChart.Series["Au (ppm)"].Enabled = false;
            }
            CheckRange();
        }

        private void clToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clToolStripMenuItem.Checked = !clToolStripMenuItem.Checked;

            if (clToolStripMenuItem.Checked)
            {
                mainChart.Series["Cl- (ppm)"].Enabled = true;
            }
            else
            {
                mainChart.Series["Cl- (ppm)"].Enabled = false;
            }
            CheckRange();
        }

        private void cl2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cl2ToolStripMenuItem.Checked = !cl2ToolStripMenuItem.Checked;

            if (cl2ToolStripMenuItem.Checked)
            {
                mainChart.Series["Cl2 (ppm)"].Enabled = true;
            }
            else
            {
                mainChart.Series["Cl2 (ppm)"].Enabled = false;
            }
            CheckRange();
        }

        private void coToolStripMenuItem_Click(object sender, EventArgs e)
        {
            coToolStripMenuItem.Checked = !coToolStripMenuItem.Checked;

            if (coToolStripMenuItem.Checked)
            {
                mainChart.Series["Co (ppm)"].Enabled = true;
            }
            else
            {
                mainChart.Series["Co (ppm)"].Enabled = false;
            }
            CheckRange();
        }

        private void niToolStripMenuItem_Click(object sender, EventArgs e)
        {
            niToolStripMenuItem.Checked = !niToolStripMenuItem.Checked;

            if (niToolStripMenuItem.Checked)
            {
                mainChart.Series["Ni (ppm)"].Enabled = true;
            }
            else
            {
                mainChart.Series["Ni (ppm)"].Enabled = false;
            }
            CheckRange();
        }

        private void feToolStripMenuItem_Click(object sender, EventArgs e)
        {
            feToolStripMenuItem.Checked = !feToolStripMenuItem.Checked;

            if (feToolStripMenuItem.Checked)
            {
                mainChart.Series["Fe (ppm)"].Enabled = true;
            }
            else
            {
                mainChart.Series["Fe (ppm)"].Enabled = false;
            }
            CheckRange();
        }

        private void sO42ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sO42ToolStripMenuItem.Checked = !sO42ToolStripMenuItem.Checked;

            if (sO42ToolStripMenuItem.Checked)
            {
                mainChart.Series["SO4 (2- ions) (ppm)"].Enabled = true;
            }
            else
            {
                mainChart.Series["SO4 (2- ions) (ppm)"].Enabled = false;
            }
            CheckRange();
        }
        private void cuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cuToolStripMenuItem.Checked = !cuToolStripMenuItem.Checked;

            if (cuToolStripMenuItem.Checked)
            {
                mainChart.Series["Cu (ppm)"].Enabled = true;
            }
            else
            {
                mainChart.Series["Cu (ppm)"].Enabled = false;
            }

            CheckRange();
        }

        #endregion

        private void dataLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataLabelsToolStripMenuItem.Checked = !dataLabelsToolStripMenuItem.Checked;

            foreach (var series in mainChart.Series)
            {
                series.IsValueShownAsLabel = dataLabelsToolStripMenuItem.Checked;
            }
        }

        #region Saving and exporting
        #region Exporting to picture
        private void exportToImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportPictureDialog.ShowDialog();
        }

        private void exportPictureDialog_FileOk(object sender, CancelEventArgs e)
        {
            mainChart.SaveImage(exportPictureDialog.FileName,
                (Path.GetExtension(exportPictureDialog.FileName) == ".jpg") ? System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg
                : System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
        }
        #endregion


        #region Saving project
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (WorkingProject.ExcelStream != null)
                {
                    saveProjectDialog.ShowDialog();
                }
                else
                {
                    throw new ApplicationException("You have not loaded any excel file and therefore the save operation cannot take place.");
                }
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Saving operation blocked",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveProjectDialog_FileOk(object sender, CancelEventArgs e)
        {
            WorkingProject.Save(saveProjectDialog.FileName);
        } 
        #endregion
        #endregion

        #region Opening files
        private void importExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDataDialog.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openProjectDialog.ShowDialog();
        }

        private void openProjectDialog_FileOk(object sender, CancelEventArgs e)
        {
            WorkingProject = new Project(openProjectDialog.FileName);

            if (WorkingProject.ReadingsData != null)
            {
                LoadChart(); 
            }
        }

        private void openDataDialog_FileOk(object sender, CancelEventArgs e)
        {
            LoadExcelFile(openDataDialog.FileName);
        }
        #endregion

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help win = new Help();
            win.BringToFront();
            win.Show();
        }
    }
}
