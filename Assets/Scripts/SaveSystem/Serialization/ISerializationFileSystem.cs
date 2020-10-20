using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SaveSystem.Serialization
{
	public interface ISerializationFileSystem : ISerializationSystem
	{
		string Extension { get; }
		string DirectoryName { get; set; }

		bool SerializeObject<T>(T obj, string key);
		T DeserializeObject<T>(string key);
	}
}
