using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
	public GameObject button;

	private void Start()
	{
		
	}

	public void OnDestroyButtonClick()
	{
		Destroy(button);
		Debug.Log("Destroyed");
	}



}
