using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
	public Text toggleText;

	public void OnToggleTrigger(bool isOn) 
	{
		switch (isOn)
		{
			case true:
				toggleText.text = "Yes";
				break;

			case false:
				toggleText.text = "No";
				break;
		}
	}
}
