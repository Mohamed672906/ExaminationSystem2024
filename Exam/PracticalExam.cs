using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
	public class PracticalExam : Exam
	{
        public PracticalExam(int _time, int _numberOfQuestions) : base(_time, _numberOfQuestions)
		{
			
        }
        public override void CreateListOfQuestions()
		{
			Questions = new Question[NumberOfQuestions];
			for (int i = 0; i < Questions?.Length; i++)
			{
				Questions[i] = new MCQQuestion();
				Questions[i].AddQuestion();
			}
		}

		public override void ShowExam()
		{
			foreach (var question in Questions)
			{
				// Question
				Console.WriteLine(question);

				// Choices
				for (int i = 0; i < question?.Answers?.Length; i++)
				{
					Console.WriteLine(question.Answers[i]);
				}
                Console.WriteLine("-------------------------------------------");
				int UserAnwserId;
				do
				{
					Console.WriteLine("Please Enter Answer Id");
				} while (!(int.TryParse(Console.ReadLine(), out UserAnwserId) && (UserAnwserId is 1 or 2 or 3)));
				question.UserAnswer.Id = UserAnwserId;
				question.UserAnswer.Text = question.Answers[UserAnwserId - 1].Text;

			}
			Console.Clear();
            Console.WriteLine("Right Answers");
			for (int i = 0;i < Questions?.Length;i++)
			{
				Console.WriteLine($"Question {i + 1} : {Questions[i].Body}");
				Console.WriteLine($"Right Answer => {Questions[i].RightAnswer.Text}");
                Console.WriteLine("----------------------------------------------------------");
            }
        }
	}
}
