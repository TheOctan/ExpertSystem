using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SaveSystem.Format
{
	public class BinarySaveSystem : FormatterSaveSystem<BinaryFormatter>
	{
		public override string Extension => "bin";
		public BinarySaveSystem(string directoryName) : base(directoryName)
		{
		}
	}
}
