using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SaveSystem.Serialization.Format
{
	public class JsonSerializationSystem : BaseSerializationFileSystem
	{
		public override string Extension => "json";

		public JsonSerializationSystem(string directoryName) : base(directoryName)
		{
		}

		protected override bool SaveObjectImplementaion<T>(Stream stream, T obj)
		{
			var json = JsonUtility.ToJson(obj);

			using (var writer = new StreamWriter(stream))
			{
				writer.WriteLine(json);
			}

			return true;
		}
		protected override T LoadObjectImplementatio<T>(Stream stream)
		{
			StringBuilder stringBuilder = new StringBuilder();
			using (var streamReader = new StreamReader(stream))
			{
				while (!streamReader.EndOfStream)
				{
					stringBuilder.Append(streamReader.ReadLine());
				}
			}

			string line = stringBuilder.ToString();
			if (string.IsNullOrEmpty(line))
			{
				return default;
			}

			var obj = JsonUtility.FromJson<T>(line);
			return obj;
		}
	}
}
