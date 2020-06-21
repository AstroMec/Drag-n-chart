using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Drag_n_chart_core;
using Drag_n_chart_core.AppException;
using System.Windows.Forms;
using System.Diagnostics;


namespace Drag_n_chart_core_test
{
    [TestClass]
    public class ExcelTests
    {
        /// <summary>
        /// This will attempt to open a docx file.
        /// </summary>
        [TestMethod]
        public void OpeningTest2()
        {
            ExcelStream file = new ExcelStream();
            try
            {
                file = new ExcelStream(@"C:\Users\maxgr\OneDrive\Documents\Fiverr\C#\Drag n chart\Sample data\New Microsoft Word Document.docx");
                Assert.Fail(); //It should not reach this point if the method works successfully.
            }
            catch (ExtensionException)
            {
                MessageBox.Show("Success!");
                file.Close();
            }
        }

        /// <summary>
        /// This is used to test whether selecting the data works. 
        /// </summary>
        [TestMethod]
        public void OpeningAndShowing()
        {
            ExcelStream xlsxfile = new ExcelStream(@"C:\Users\maxgr\OneDrive\Documents\Fiverr\C#\Drag n chart\Sample data\Data Template 2b.xlsx");

            xlsxfile.Select(4);

            string actual = xlsxfile.GetCellData(5, 4).ToString().Trim();
            string expected = "2.26";
            Assert.AreEqual(expected, actual);
            xlsxfile.Close();

        }

        /// <summary>
        /// This tests the Start property.
        /// </summary>
        [TestMethod]
        public void OpeningAndShowing2()
        {
            ExcelStream xlsxfile = new ExcelStream(@"C:\Users\maxgr\OneDrive\Documents\Fiverr\C#\Drag n chart\Sample data\Data Template 2b.xlsx");

            xlsxfile.Select(4);
            Tuple<int, int> start = xlsxfile.Start;

            string actual = xlsxfile.GetCellData(start.Item1 + 1, start.Item2 + 1).ToString().Trim();
            string expected = "0";

            Assert.AreEqual(expected, actual);

            xlsxfile.Close();
        }

        /// <summary>
        /// This tests the GetAllSheetData() method.
        /// </summary>
        [TestMethod]
        public void GetAllSheetDataTest()
        {
            ExcelStream xlsxfile = new ExcelStream(@"C:\Users\maxgr\OneDrive\Documents\Fiverr\C#\Drag n chart\Sample data\Data Template 2b.xlsx");

            xlsxfile.Select(4);
            var test = xlsxfile.GetAllSheetData();
        }
    }
}
