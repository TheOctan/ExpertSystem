using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SaveSystem.Serialization
{
	public interface ISerializationSystem
	{
		bool SaveObject<T>(T obj);
		T LoadObject<T>();
	}
}
