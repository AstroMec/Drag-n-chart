using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Drag_n_chart.Forms;

namespace Drag_n_chart
{
    static class Program
    {
        public static string[] MainArgs { get; set; } = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 1)
                {
                    throw new ApplicationException("One file can be dragged at a time.");
                }
                else if (args.Length != 0)
                {
                    MainArgs = args; //Args include which file has been dragged.
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainScreen());
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Error occured while starting application", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
