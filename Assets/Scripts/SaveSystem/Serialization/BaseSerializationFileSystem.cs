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
		public string LastKey { get => lastKey != "" ? lastKey : DefaultKey; set => lastKey = value; }
		public string SavePath => DirectoryName + LastKey + "." + Extension;
		public virtual string DefaultKey => "SaveFile";

		private string lastKey;

		public BaseSerializationFileSystem(string directoryName)
		{
			DirectoryName = directoryName;
		}

		public virtual bool SaveObject<T>(T obj)
		{
			return SaveObject(obj, LastKey);
		}
		public virtual bool SaveObject<T>(T obj, string key)
		{
			LastKey = key;
			if (!Directory.Exists(DirectoryName))
			{
				Directory.CreateDirectory(DirectoryName);
			}

			using (FileStream stream = new FileStream(SavePath, FileMode.Create))
			{
				return SaveObjectImplementaion(stream, obj);
			}
		}
		public T LoadObject<T>()
		{
			return LoadObject<T>(LastKey);
		}
		public virtual T LoadObject<T>(string key)
		{
			LastKey = key;

			using (FileStream stream = new FileStream(SavePath, FileMode.Open))
			{
				return LoadObjectImplementatio<T>(stream);
			}
		}

		protected abstract bool SaveObjectImplementaion<T>(Stream stream, T obj);
		protected abstract T LoadObjectImplementatio<T>(Stream stream);
	}
}
