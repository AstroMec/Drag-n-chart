using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace Drag_n_chart_core
{
	public class Project
	{
		public ExcelStream ExcelStream { get; set; }

		public Readings? ReadingsData { get; set; } = null;

		public void Save(string path)
        {
			Serializer<Project>.Serialize(this, path);
        }

		public Project()
        {
        }

		public Project(string path)
        {
			Project opened = Serializer<Project>.Deserialize(path);
			ExcelStream = opened.ExcelStream;
			ReadingsData = opened.ReadingsData;
			OnDeserialized();
        }

		private void OnDeserialized()
        {
			ExcelStream.Load();
        }
	}
}
