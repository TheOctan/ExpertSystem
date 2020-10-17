using Assets.Scripts.SaveSystem;
using Assets.Scripts.SaveSystem.Format;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducationMenu : MonoBehaviour
{
	private BaseSaveFileSystem saveSystem;

	private void Awake()
	{
		saveSystem = new XmlSaveSystem(Application.persistentDataPath + "/Saves/");
	}

	public void OnLoadButtonClick()
	{
		Debug.Log(Application.persistentDataPath);

		var objData = saveSystem.LoadObject<EducationData>("education");
		Debug.Log(objData);
	}

	public void OnSaveButtonClick()
	{
		Debug.Log(Application.persistentDataPath);

		var data = new EducationData()
		{
			Objects = new List<string>()
			{
				"Name1",
				"Name2",
				"Name3"
			},
			Questions = new List<string>()
			{
				"Quest1",
				"Quest2",
				"Quest3"
			},
			Answers = new List<bool>()
			{
				true, true, true,
				false, false, false,
				true, true, true
			}
		};

		saveSystem.SaveObject(data, "education");
	}
}
