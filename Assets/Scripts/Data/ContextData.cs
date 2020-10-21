using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data
{
	public class ContextData
	{
		public List<string> Objects { get; set; }
		public List<string> Questions { get; set; }
		public List<List<bool>> Answers { get; set; }

		public ContextData()
		{
			Answers = new List<List<bool>>();
		}

		public ContextData(EducationData educationData) : this()
		{
			SetEducationData(educationData);
		}

		public EducationData GetEducationData()
		{
			var educationData = new EducationData()
			{
				objects = Objects,
				questions = Questions,
				answers = new List<bool>()
			};
			
			Answers.ForEach(list => educationData.answers.AddRange(list));

			return educationData;
		}

		public ContextData SetEducationData(EducationData educationData)
		{
			Objects = educationData.objects;
			Questions = educationData.questions;

			int width = educationData.questions.Count;
			int height = educationData.objects.Count;
			
			for (int i = 0; i < width; i++)
			{
				var step = height * i;
				var count = height;

				Answers.Add(educationData.answers.GetRange(step, count));
			}

			return this;
		}
	}
}
