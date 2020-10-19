using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SaveSystem.Serialization.Format
{
	public class SoapSerializationSystem : FormatterSaveSystem<SoapFormatter>
	{
		public override string Extension => "soap";
		public SoapSerializationSystem(string directoryName) : base(directoryName)
		{
		}
	}
}
