using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class EducationData
{
	public List<string> objects;
	public List<string> questions;
	public List<bool> answers;

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();

		stringBuilder.Append("Object names: ");
		objects.ForEach((obj) => stringBuilder.Append(obj + " "));
		
		stringBuilder.Append("\nQuestions: ");
		questions.ForEach((obj) => stringBuilder.Append(obj + " "));
		
		stringBuilder.Append("\nAnswers: ");
		answers.ForEach((obj) => stringBuilder.Append(obj + " "));

		return stringBuilder.ToString();
	}
}

