using System;
using Drag_n_chart_core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drag_n_chart_core_test
{
    /// <summary>
    /// This tests the serialization of a project.
    /// </summary>
    [TestClass]
    public class ProjectTests
    {
        /// <summary>
        /// Serialization test.
        /// </summary>
        [TestMethod]
        public void SavingProjects()
        {
            ExcelStream excelStream = new ExcelStream(@"C:\Users\maxgr\OneDrive\Documents\Fiverr\C#\Drag n chart\Sample data\Data Template 2b.xlsx");
            excelStream.Select(4);
            Project testProj = new Project() { ExcelStream = excelStream, ReadingsData = excelStream.GetAllSheetData() };
            testProj.Save(@"C:\Users\maxgr\Desktop\test file.xml");
        }

        /// <summary>
        /// De-serialization test.
        /// </summary>
        [TestMethod]
        public void OpeningProject()
        {
            Project testProj = new Project(@"C:\Users\maxgr\Desktop\test file.xml");
        }
    }
}
