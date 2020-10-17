using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class EducationData
{
	public List<string> Objects { get; set; }
	public List<string> Questions { get; set; }
	public List<bool> Answers { get; set; }

	public EducationData()
	{
		
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();

		stringBuilder.Append("Object names: ");
		Objects.ForEach((obj) => stringBuilder.Append(obj + " "));
		
		stringBuilder.Append("\nQuestions: ");
		Questions.ForEach((obj) => stringBuilder.Append(obj + " "));
		
		stringBuilder.Append("\nAnswers: ");
		Answers.ForEach((obj) => stringBuilder.Append(obj + " "));

		return stringBuilder.ToString();
	}
}

