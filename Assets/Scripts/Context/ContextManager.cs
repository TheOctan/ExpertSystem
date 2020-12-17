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

		var questionInput = GetInputFields("Question").ToArray();
		var objectsInput = GetInputFields("NameObject").ToArray();

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
		if(ContextData == null)
		{
			ContextData = new ContextData();
		}
		else
		{
			ContextData.Answers.Clear();
		}

		ContextData.Questions = GetInputFields("Question").Select(e => e.text).ToList();
		ContextData.Objects = GetInputFields("NameObject").Select(e => e.text).ToList();

		for (int i = columnOffset; i < transform.childCount - columnsAfter; i++)
		{
			var column = transform.GetChild(i);
			ContextData.Answers.Add(column.GetComponentsInChildren<Toggle>().Select(obj => obj.isOn).ToList());
		}

		return ContextData;
	}

	public void SaveContext()
	{
		ReadContext();
	}

	private IEnumerable<InputField> GetInputFields(string tag)
	{
		var gameObjects = GameObject.FindGameObjectsWithTag(tag);
		var inputFieldComponents = gameObjects.Select(obj => obj.GetComponent<InputField>());

		return inputFieldComponents;
	}
}
