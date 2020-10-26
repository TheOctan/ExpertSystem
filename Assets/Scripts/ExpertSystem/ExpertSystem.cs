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
		private int currentQuestionIndex = -1;

		private ContextData contextData = null;
		private ContextData cache;

		private State state;

		private enum State
		{
			Standart = 0,
			QuestionEnded,
			ObjectsEnded
		}

		public ExpertSystem()
		{
			IsStarted = false;
			cache = new ContextData();
			state = State.Standart;
		}
		public ExpertSystem(ContextData context) : this()
		{
			SetContext(context);
		}

		public bool SetContext(ContextData context)
		{
			if (context.IsValid)
			{
				Reset();
				contextData = context;
				cache = context;

				return true;
			}
			else
			{
				return false;
			}
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
			if (IsStarted)
			{
				cache = contextData;
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool SetCurrentAnswer(bool answer)
		{
			if (IsStarted)
			{
				switch (state)
				{
					case State.Standart:
						ShrinkContext(answer);

						if (cache.Questions.Count > 0)
						{
							currentQuestiuon = GetNextQuestion();
							OnQuestionChanged?.Invoke(currentQuestiuon);

							if (cache.Objects.Count == 1)
							{
								OnEnded?.Invoke($"It's a {cache.Objects[0]}!");
							}
						}
						else
						{
							if (cache.Objects.Count > 1)
							{
								state = State.QuestionEnded;

								var objects = cache.Objects;
								OnQuestionChanged?.Invoke($"Is it a {objects[0]}?");
							}
							else
							{
								OnEnded?.Invoke("I do not know what this object is!");
							}
						}
						break;
					case State.QuestionEnded:

						if (cache.Objects.Count > 1)
						{
							if (answer)
							{
								OnEnded?.Invoke($"It's a {cache.Objects[0]}!");
							}
							else
							{
								var objects = cache.Objects;
								objects.RemoveAt(0);
								OnQuestionChanged?.Invoke($"Is it a {objects[0]}?");
							}
						}
						else
						{
							OnEnded?.Invoke("I do not know what this object is!");
						}

						break;
				}

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
			var questionWeights = cache.Answers.Select(quest => quest.Count(e => e)).ToList();
			var minWeight = questionWeights.Min();
			var questionIndex = questionWeights.ToList().IndexOf(minWeight);

			currentQuestionIndex = questionIndex;

			return contextData.Questions[questionIndex];
		}
		private void ShrinkContext(bool answer)
		{
			var currentQuestionWeights = cache.Answers[currentQuestionIndex];

			for (int i = 0; i < currentQuestionWeights.Count;)
			{
				if (currentQuestionWeights[i] != answer)
				{
					cache.Objects.RemoveAt(i);
					RemoveObjectAnswers(i);
				}
				else
				{
					i++;
				}
			}

			cache.Answers.RemoveAt(currentQuestionIndex);
			cache.Questions.RemoveAt(currentQuestionIndex);
		}
		private void RemoveObjectAnswers(int index)
		{
			for (int i = 0; i < cache.Answers.Count; i++)
			{
				cache.Answers[i].RemoveAt(index);
			}
		}
	}
}
