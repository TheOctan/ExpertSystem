using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data
{
	public class ContextData
	{
		public List<string> Objects { get; set; }
		public List<string> Questions { get; set; }
		public List<List<bool>> Answers { get; set; }

		public ContextData()
		{
			Answers = new List<List<bool>>();
		}
	}
}
