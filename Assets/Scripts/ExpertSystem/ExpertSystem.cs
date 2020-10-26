using Assets.Scripts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ExpertSystem
{
	public class ExpertSystem
	{
		public bool IsReady => contextData != null;
		public bool IsStarted { get; private set; }

		public event Action<string> OnQuestionChanged;
		public event Action<string> OnEnded;
		public event Action<string> OnSendWarningMessage;

		private string currentQuestiuon = "";
		private ContextData contextData = null;
		private ContextData cache;

		public ExpertSystem()
		{
			IsStarted = false;
			cache = new ContextData();
		}

		public ExpertSystem(ContextData context) : this()
		{
			SetContext(context);
		}

		public void SetContext(ContextData context)
		{
			Reset();
			contextData = context;
		}

		public bool Start()
		{
			if (IsReady)
			{
				IsStarted = true;
				currentQuestiuon = GetNextQuestion();
				OnQuestionChanged?.Invoke(currentQuestiuon);

				return true;
			}
			else
			{
				OnSendWarningMessage?.Invoke("Context is not initialized!");
				return false;
			}
		}

		public bool Reset()
		{
			return true;
		}

		public bool SetCurrentAnswer(bool answer)
		{
			if (IsStarted)
			{


				return true;
			}
			else
			{
				OnSendWarningMessage?.Invoke("System is not staeted!");
				return false;
			}
		}

		private string GetNextQuestion()
		{
			var questionWeights = contextData.Answers.Select(quest => quest.Count(e => e)).ToList();
			var minWeight = questionWeights.Min();
			var questionIndex = questionWeights.ToList().IndexOf(minWeight);

			Debug.Log(questionIndex);


			return contextData.Questions[questionIndex];
		}
	}
}
