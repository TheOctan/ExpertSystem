using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SaveSystem
{
	public abstract class BaseSaveFileSystem : ISaveSystem
	{
		public string DirectoryName { get; set; }
		public abstract string Extension { get; }
		public string LastKey { get => lastKey != "" ? lastKey : DefaultKey; set => lastKey = value; }
		public string SavePath => DirectoryName + LastKey + "." + Extension;
		protected virtual string DefaultKey => "SaveFile";

		private string lastKey;

		public BaseSaveFileSystem(string directoryName)
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
			Directory.CreateDirectory(DirectoryName);

			return SaveObjectImplementaion();
		}
		public virtual T LoadObject<T>(string key)
		{
			LastKey = key;

			return LoadObjectImplementatio<T>();
		}

		protected abstract bool SaveObjectImplementaion();
		protected abstract T LoadObjectImplementatio<T>();
	}
}
