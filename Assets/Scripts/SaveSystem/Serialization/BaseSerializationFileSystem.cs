using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SaveSystem.Serialization
{
	public abstract class BaseSerializationFileSystem : ISerializationFileSystem, ISerializationSystem
	{
		public string DirectoryName { get; set; }
		public abstract string Extension { get; }
		public virtual string DefaultKey => "SaveFile";

		public BaseSerializationFileSystem(string directoryName)
		{
			DirectoryName = directoryName;
		}

		public virtual bool SaveObject<T>(T obj)
		{
			return SaveObject(obj, DefaultKey);
		}
		public virtual bool SaveObject<T>(T obj, string key)
		{
			if (!Directory.Exists(DirectoryName))
			{
				Directory.CreateDirectory(DirectoryName);
			}

			using (FileStream stream = new FileStream(SavePath(key), FileMode.Create))
			{
				return SaveObjectImplementaion(stream, obj);
			}
		}
		public T LoadObject<T>()
		{
			return LoadObject<T>(DefaultKey);
		}
		public virtual T LoadObject<T>(string key)
		{
			if(!File.Exists(SavePath(key)))
			{
				return default;
			}

			using (FileStream stream = new FileStream(SavePath(key), FileMode.Open))
			{
				return LoadObjectImplementatio<T>(stream);
			}
		}

		private string SavePath(string key)
		{
			return DirectoryName + key + "." + Extension;
		}

		protected abstract bool SaveObjectImplementaion<T>(Stream stream, T obj);
		protected abstract T LoadObjectImplementatio<T>(Stream stream);
	}
}
