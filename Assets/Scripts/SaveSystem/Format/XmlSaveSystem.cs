using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assets.Scripts.SaveSystem.Format
{
	public class XmlSaveSystem : BaseSaveFileSystem
	{
		public override string Extension => "xml";
		public XmlSaveSystem(string directoryName) : base(directoryName)
		{
		}

		protected override T LoadObjectImplementatio<T>(Stream stream)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			var obj = (T)serializer.Deserialize(stream);

			return obj;
		}

		protected override bool SaveObjectImplementaion<T>(Stream stream, T obj)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			serializer.Serialize(stream, obj);

			return true;
		}
	}
}
