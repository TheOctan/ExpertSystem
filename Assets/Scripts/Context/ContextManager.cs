using Assets.Scripts.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ContentManager))]
public class ContextManager : MonoBehaviour
{
	public ContextData ContextData { get; private set; }

	private ContentManager contentManager;
	private readonly int columnOffset = 2;
	private readonly int columnsAfter = 1;

	private void Awake()
	{
		contentManager = GetComponent<ContentManager>();
	}

	public void UpdateContext(ContextData contextData)
	{
		ContextData = contextData;

		int width = contextData.Questions.Count;
		int height = contextData.Objects.Count;

		contentManager.UpdateSize(width, height);

		var questionInput = GameObject.FindGameObjectsWithTag("Question").Select(obj => obj.GetComponent<InputField>()).ToArray();
		var objectsInput = GameObject.FindGameObjectsWithTag("NameObject").Select(obj => obj.GetComponent<InputField>()).ToArray();

		for (int i = 0; i < width; i++)
		{
			questionInput[i].text = contextData.Questions[i];
		}

		for (int i = 0; i < height; i++)
		{
			objectsInput[i].text = contextData.Objects[i];
		}

		for (int i = 0; i < width; i++)
		{
			var column = transform.GetChild(i + columnOffset);
			var toggles = column.GetComponentsInChildren<Toggle>();
			for (int j = 0; j < height; j++)
			{
				toggles[j].isOn = contextData.Answers[i][j];
			}
		}		
	}

	public ContextData ReadContext()
	{
		ContextData.Questions = GameObject.FindGameObjectsWithTag("Question").Select(obj => obj.GetComponent<InputField>().text).ToList();
		ContextData.Objects = GameObject.FindGameObjectsWithTag("NameObject").Select(obj => obj.GetComponent<InputField>().text).ToList();

		ContextData.Answers.Clear();
		for (int i = columnOffset; i < transform.childCount - columnsAfter; i++)
		{
			var column = transform.GetChild(i);
			ContextData.Answers.Add(column.GetComponentsInChildren<Toggle>().Select(obj => obj.isOn).ToList());
		}

		return ContextData;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			UpdateContext(new ContextData()
			{
				Questions = new List<string>() { "Have a wheel?", "Have a wings?", "It's a live object?" },
				Objects = new List<string>() { "Car", "Plane", "Bird" },
				Answers = new List<List<bool>>() { new List<bool>() { true, true, false }, new List<bool>() { false, true, true }, new List<bool>() { false, false, true } }
			});
		}
	}
}
