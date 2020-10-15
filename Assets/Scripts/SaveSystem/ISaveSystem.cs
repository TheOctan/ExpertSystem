using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SaveSystem
{
	public interface ISaveSystem
	{
		bool SaveObject<T>(T obj);
		bool SaveObject<T>(T obj, string key);
		T LoadObject<T>(string key);
	}
}
