using Assets.Scripts.Data;
using Assets.Scripts.SaveSystem;
using Assets.Scripts.SaveSystem.Serialization;
using Assets.Scripts.SaveSystem.Serialization.Format;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EducationMenu : MonoBehaviour
{
	private readonly string saveKey = "education";
	
	public ContextManager contextManager;

	public void OnLoadButtonClick()
	{
		var educationData = SaveSystem.Load<EducationData>(saveKey);
		contextManager.UpdateContext(new ContextData(educationData));
	}

	public void OnSaveButtonClick()
	{
		var contextData = contextManager.ReadContext();
		SaveSystem.Save(saveKey, contextData.GetEducationData());
	}
}
