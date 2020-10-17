using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public void OnExitButtonClick()
	{
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
#else
	Application.Quit();
#endif
		Application.Quit();
	}
}
