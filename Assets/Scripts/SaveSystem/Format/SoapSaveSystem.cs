using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SaveSystem.Format
{
	public class SoapSaveSystem : FormatterSaveSystem<SoapFormatter>
	{
		public override string Extension => "soap";
		public SoapSaveSystem(string directoryName) : base(directoryName)
		{
		}
	}
}
