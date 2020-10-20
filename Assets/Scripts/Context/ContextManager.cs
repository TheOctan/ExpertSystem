using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ContentManager))]
public class ContextManager : MonoBehaviour
{
	private ContentManager contentManager;

	public List<string> Objects { get; set; }
	public List<string> Questions { get; set; }
	public List<List<bool>> Answers { get; set; }

	private void Awake()
	{
		contentManager = GetComponent<ContentManager>();
		Answers = new List<List<bool>>();
	}

	private void Start()
	{

	}

	public void UpdateContext()
	{
		
	}

	public void ReadContext()
	{
		Objects = GameObject.FindGameObjectsWithTag("NameObject").Select(obj => obj.GetComponent<InputField>().text).ToList();
		Questions = GameObject.FindGameObjectsWithTag("Question").Select(obj => obj.GetComponent<InputField>().text).ToList();

		Answers.Clear();
		for (int i = 2; i < transform.childCount - 1; i++)
		{
			var column = transform.GetChild(i);
			Answers.Add(column.GetComponentsInChildren<Toggle>().Select(obj => obj.isOn).ToList());
		}

		Answers.ForEach(answer => answer.ForEach(item => Debug.Log(item)));
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ReadContext();
		}
	}
}
