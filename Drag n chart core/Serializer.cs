using System.IO;
using System.Xml.Serialization;

namespace Drag_n_chart_core
{
    public static class Serializer<T> where T : class
	{
		public static void Serialize(T o, string path)
        {
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			Stream stream = new FileStream(path, FileMode.OpenOrCreate);
			serializer.Serialize(stream, o);
			stream.Close();
			stream.Dispose();
        }

		public static T Deserialize(string path)
        {
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			Stream stream = new FileStream(path, FileMode.Open);
			T result = xmlSerializer.Deserialize(stream) as T;
			stream.Close();
			stream.Dispose();
			return result;
		}
	}
}
