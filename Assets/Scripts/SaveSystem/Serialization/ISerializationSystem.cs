using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SaveSystem.Serialization
{
	public interface ISerializationSystem
	{
		bool SerializeObject<T>(T obj);
		T DeserializeObject<T>();
	}
}
