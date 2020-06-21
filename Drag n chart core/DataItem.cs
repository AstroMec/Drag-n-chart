using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Drag_n_chart_core
{
    public struct DataItem
    {
        public DateTime? Date { get; set; }

        public int? Days { get; set; }
                     
        public double? pH { get; set; }
                     
        public double? Eh { get; set; } //(mV)
                     
        public double? Density { get; set; } //(g/ml)
                     
        public double? DO { get; set; } //(mg/l)
                     
        public double? T_atm { get; set; } //(°C)
                     
        public double? T_wat { get; set; } //(°C)
                     
        public double? Ag { get; set; } //(ppm)
                     
        public double? Au { get; set; } //(ppm)
                     
        public double? Cl_minus { get; set; } //(ppm)
                     
        public double? Cl2 { get; set; } //(ppm)
                     
        public double? Co { get; set; } //(ppm)
                     
        public double? Cu { get; set; } //(ppm)
                     
        public double? Ni { get; set; } //(ppm)
                     
        public double? Fe { get; set; } //(ppm)
                     
        public double? SO4_2minus { get; set; } //(ppm)

    }

    public struct Readings
    {
        public DataItem[] DataItems { get; set; }

        /// <summary>
        /// This indexer will allow me to search for a data item with ease.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataItem this[DateTime date]
        {
            get
            {
                return DataItems.AsParallel().Where(d => d.Equals(date)).FirstOrDefault();
            }
        }

        /// <summary>
        /// This will enable me to iterate through this data structure.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Array> GetEnumerator()
        {
            return (IEnumerator<Array>)DataItems.GetEnumerator();
        }
    }
}
