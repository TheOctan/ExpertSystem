using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SaveSystem
{
	public abstract class FormatterSaveSystem<T> : BaseSaveFileSystem where T : IFormatter, new()
	{
		public override abstract string Extension { get; }

		public FormatterSaveSystem(string directoryName) : base(directoryName)
		{
		}

		protected override T1 LoadObjectImplementatio<T1>(Stream stream)
		{
			var formatter = new T();
			T1 obj = (T1)formatter.Deserialize(stream);

			return obj;
		}

		protected override bool SaveObjectImplementaion<T1>(Stream stream, T1 obj)
		{
			var formatter = new T();
			formatter.Serialize(stream, obj);

			return true;
		}
	}
}
