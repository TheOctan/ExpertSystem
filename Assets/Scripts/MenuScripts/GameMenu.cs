using Assets.Scripts.ExpertSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
	public Text questionText;
	public ContextManager contextManager;

	private ExpertSystem expertSystem;

	private void Awake()
	{
		expertSystem = new ExpertSystem();
		expertSystem.OnQuestionChanged += UpdateQuestion;
	}

	private void OnEnable()
	{
		expertSystem.SetContext(contextManager.ContextData);
		expertSystem.Start();
	}

	public void AnswerButtonClick(bool answer)
	{
		expertSystem.SetCurrentAnswer(answer);
	}
	public void ResetButtonClick()
	{
		expertSystem.Reset();
	}
	private void UpdateQuestion(string question)
	{
		questionText.text = question;
	}
}
