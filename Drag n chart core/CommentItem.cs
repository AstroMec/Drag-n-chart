using System;
using System.Collections.Generic;

namespace Drag_n_chart_core
{
    public struct CommentItem
    {
        public TimeSpan? Time { get; set; }

        public string Comment { get; set; }

        public double? MorningFlow { get; set; }

        public double? AfternoonFlow { get; set; }

        /// <summary>
        /// This will be written to the labels.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Comment: {Comment}\nTime: {Time}, Morning flow-rate: {MorningFlow}, Afternoon flow-rate: {AfternoonFlow}";
        }
    }

    #region Helper structures
    public struct TempCommentHolder
    {
        public DateTime Date { get; set; }

        public string Comment { get; set; }

        public TimeSpan? Time { get; set; }

        public double? MorningFlow { get; set; }

        public double? AfternoonFlow { get; set; }
    }

    public struct TempCommentHolders
    {
        public TempCommentHolder[] Items { get; set; }

        public TempCommentHolders(ExcelStream excelStream)
        {
            excelStream.Select(1);
            int startRow = excelStream.Start.Item1 + 1; //Becuase we are ignoring the headings.
            int startCol = excelStream.Start.Item2;
            List<string> emptyString = new List<string> { "", " ", string.Empty, null };


            List<TempCommentHolder> toAdd = new List<TempCommentHolder>();

            for (int rowID = startRow; rowID <= excelStream.RowCount; rowID++)
            {
                toAdd.Add(new TempCommentHolder()
                {
                    Date = (DateTime)excelStream.GetCellData(rowID, startCol, true),
                    Time = (!emptyString.Contains((string)excelStream.GetCellData(rowID, startCol + 1))) ?
                        (TimeSpan?)TimeSpan.Parse(((string)excelStream.GetCellData(rowID, startCol + 1)).Replace(';', ':')) : null,

                    MorningFlow = (!emptyString.Contains((string)excelStream.GetCellData(rowID, startCol + 3))) ?
                            (double?)double.Parse((string)excelStream.GetCellData(rowID, startCol + 3)) : null,

                    AfternoonFlow = (!emptyString.Contains((string)excelStream.GetCellData(rowID, startCol + 4))) ?
                            (double?)double.Parse((string)excelStream.GetCellData(rowID, startCol + 4)) : null,

                    Comment = (string)excelStream.GetCellData(rowID, startCol + 5)
                });
            }

            Items = toAdd.ToArray();
        }
    } 
    #endregion
}
