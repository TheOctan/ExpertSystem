using Assets.Scripts.SaveSystem.Serialization;
using Assets.Scripts.SaveSystem.Serialization.Format;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SaveSystem
{
	public class SaveSystem
	{
		private static ISerializationFileSystem serializationFileSystem = new JsonSerializationSystem(Application.persistentDataPath + "/Saves");

		public static bool Save<T>(string saveName, T saveData)
		{
			return serializationFileSystem.SerializeObject<T>(saveData, saveName);
		}
		public static T Load<T>(string path)
		{
			try
			{
				return serializationFileSystem.DeserializeObject<T>(path);
			}
			catch
			{
				Debug.LogError($"Failed to load file at {path}");
				return default;
			}
		}
		public static void SetSaveDirectory(string directory)
		{
			serializationFileSystem.DirectoryName = directory;
		}
	}
}
