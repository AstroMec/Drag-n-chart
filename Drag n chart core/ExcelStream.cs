using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Linq;
using Drag_n_chart_core.AppException;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Drag_n_chart_core
{
	public class ExcelStream
	{
        //todo add a check extension method.
		internal string path;

        #region Properties
        [XmlIgnore]
        public Application ExcelApp { get; set; } = new Application() { Visible = true };

        /// <summary>
        /// This will get the index of the start.
        /// </summary>
        /// <returns></returns>
        [XmlIgnore]
        public Tuple<int, int> Start
        {
            get
            {
                try
                {
                    for (int i = 1; i <= RowCount; i++)
                    {
                        for (int j = 1; j <= ColCount; j++)
                        {
                            if (GetCellData(i, j).ToString() == "Date")
                                return new Tuple<int, int>(i, j);
                        }
                    }

                    throw new FileNotValidException("Sheet has no start. " +
                        "\nEither the document is not formatted properly or the sheet is not an internal company file." +
                        "\n(Maybe change the top left cell Date)"); //If there is no start, it may mean that the selected file 
                                                                    //is not an internal company file.
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// This is the path to the concerned excel file.
        /// </summary>
        public string Path
        {
            get => path;

            set
            {
                try
                {
                    string[] pathArray = value.Split('\\');

                    if (!new string[] { "xlsx", "csv", "xls" }.Contains(pathArray.Last().Split('.').Last()))
                    {
                        throw new ExtensionException("Only extensions associated with excel are supported!");
                    }
                    else
                    {
                        path = value;
                    }
                }
                catch
                {
                    throw;
                }
            }
        }

        [XmlIgnore]
        public Workbook Workbook { get; set; }

        [XmlIgnore]
        public _Worksheet CurrentWorksheet { get; set; }

        /// <summary>
        /// This property allows me to get the active range of cells (used range in excel sheet).
        /// </summary>
        [XmlIgnore]
        public Range ExcelRange { get; set; }

        public int RowCount { get => ExcelRange.Rows.Count; }

        public int ColCount { get => ExcelRange.Columns.Count; }

        /// <summary>
        /// This used in the deserialisation.
        /// </summary>
        public int? SelectedSheetIndex { get; set; } = null;

        /// <summary>
        /// This contructor opens the file in the program.
        /// </summary>
        /// <param name="filePath"></param>
        public ExcelStream(string filePath)
        {
            Path = filePath;
            Workbook = ExcelApp.Workbooks.Open(Path);
        } 
        #endregion

        public ExcelStream()
        {
        }

		/// <summary>
		/// Note to dev: remember that the index starts from 1 NOT 0!
		/// </summary>
		/// <param name="index">Index is the index of the sheet.</param>
		/// <returns></returns>
		public _Worksheet this[int index]
		{
			get
			{
				if (index > 0)
				{
					return (_Worksheet)Workbook.Sheets[index];
				}
				else
				{
					throw new ApplicationException("The index starts with 1. Not 0.");
				}
			}
		}

		public void Select(int index)
		{
			CurrentWorksheet = this[index];
			ExcelRange = CurrentWorksheet.UsedRange;
            SelectedSheetIndex = index;
		}

		/// <summary>
		/// Because you need to release com objects to close the excel app 
		/// (to prevent it from running in the background).
		/// </summary>
		public void Close()
		{
			Marshal.ReleaseComObject(ExcelRange);
			Marshal.ReleaseComObject(CurrentWorksheet);

			Workbook.Close();
			Marshal.ReleaseComObject(Workbook);

			ExcelApp.Quit();
			Marshal.ReleaseComObject(ExcelApp);
		}

		/// <summary>
		/// This destructor is called when the program exits.
		/// </summary>
		~ExcelStream()
		{
            try
            {
                this.Close();
            }
            catch
            {
            }
		}

		/// <summary>
		/// This will get the data in the cells. Assumes that the sheet is selected first.
		/// </summary>
		/// <param name="rowIndex">Row</param>
		/// <param name="columnIndex">Column</param>
		/// <returns></returns>
		public object GetCellData(int rowIndex, int columnIndex)
		{
			return (CurrentWorksheet.Cells[rowIndex, columnIndex] as Range).Text;
		}

		public object GetCellData(Tuple<int, int> index)
		{
			return GetCellData(index.Item1, index.Item2);
		}

		/// <summary>
		/// This will parse all the data from the current sheet. It assumes that the sheet has been selected.
		/// </summary>
		/// <returns></returns>
		public Readings GetAllSheetData()
		{
            try
            {
                Workbook.RefreshAll(); //This will update the dates to match the default culture of the computer.

                Tuple<int, int> dataStart = Start;
                var currentIndex = dataStart;
                currentIndex = new Tuple<int, int>(currentIndex.Item1 + 1, currentIndex.Item2); //Skips the first row because it's the headings.

                DateTime? currentDate = (DateTime?)DateTime.Parse(GetCellData(currentIndex).ToString());

                List<DataItem> dataItems = new List<DataItem>();

                #region Local functions
                bool isEmpty(int i, int j)
                {
                    string[] empty = new string[] { "", " ", string.Empty };
                    return empty.Contains(GetCellData(i, j).ToString());
                }

                double? isEmptyDouble(int from, int plus)
                {
                    //Basically, if the cell is empty, this function will return null, otherwise, it will return a double.
                    return !isEmpty(currentIndex.Item1, from + plus) ?
                        (double?)double.Parse(GetCellData(currentIndex.Item1, from + plus).ToString()) : null;
                }
                #endregion

                for (int i = dataStart.Item1; i <= ExcelRange.Rows.Count; i++)
                {
                    int numericDataStart = dataStart.Item2 + 1; //This will get the first column where the data starts


                    dataItems.Add(new DataItem()
                    {
                        Date = currentDate,
                        Days = !isEmpty(currentIndex.Item1, numericDataStart) ?
                                (int?)int.Parse(GetCellData(currentIndex.Item1, numericDataStart).ToString()) : null,

                        pH = isEmptyDouble(numericDataStart, 1),

                        Eh = isEmptyDouble(numericDataStart, 2),

                        Density = isEmptyDouble(numericDataStart, 3),

                        DO = isEmptyDouble(numericDataStart, 4),

                        T_atm = isEmptyDouble(numericDataStart, 5),

                        T_wat = isEmptyDouble(numericDataStart, 6),

                        Ag = isEmptyDouble(numericDataStart, 7),

                        Au = isEmptyDouble(numericDataStart, 8),

                        Cl_minus = isEmptyDouble(numericDataStart, 9),

                        Cl2 = isEmptyDouble(numericDataStart, 10),

                        Co = isEmptyDouble(numericDataStart, 11),

                        Cu = isEmptyDouble(numericDataStart, 12),

                        Ni = isEmptyDouble(numericDataStart, 13),

                        Fe = isEmptyDouble(numericDataStart, 14),

                        SO4_2minus = isEmptyDouble(numericDataStart, 15)

                    });

                    currentIndex = new Tuple<int, int>(currentIndex.Item1 + 1, currentIndex.Item2); //Increment the row number by 1.

                    currentDate = (!isEmpty(currentIndex.Item1, currentIndex.Item2)) ?
                    (DateTime?)DateTime.Parse(GetCellData(currentIndex).ToString()) : null;
                }

                return new Readings() { DataItems = dataItems.ToArray() };
            }
            catch (FormatException ex)
            {
				//Can't expect the data to be perfectly entered.
                throw new FormatException($"There was an error in parsing the data. " +
					$"\nThe data may not have been entered properly (maybe there are two decimal points instead of one?). " +
					$"\n{ex.Data}");
            }
			catch
            {
				throw;
            }
		}

        public void Load()
        {
            ExcelApp = new Application() { Visible = true };
            Workbook = ExcelApp.Workbooks.Open(Path);

            if (SelectedSheetIndex != null)
                Select((int)SelectedSheetIndex);
        }
	}
}
