using Assets.Scripts.ExpertSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
	public Text questionText;
	public ContextManager contextManager;

	[Header("Buttons")]
	public Button yesButton;
	public Button noButton;

	private ExpertSystem expertSystem;

	private void Awake()
	{
		expertSystem = new ExpertSystem();
		expertSystem.OnQuestionChanged += UpdateQuestion;
		expertSystem.OnSendWarningMessage += HandleWarningMessage;
		expertSystem.OnEnded += GameOver;
	}

	private void GameOver(string answer)
	{
		yesButton.interactable = false;
		noButton.interactable = false;

		questionText.text = answer;
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
		expertSystem.Restart();
		yesButton.interactable = true;
		noButton.interactable = true;
	}
	private void UpdateQuestion(string question)
	{
		questionText.text = question;
	}
	private void HandleWarningMessage(string message)
	{
		questionText.text = message;
	}
}
