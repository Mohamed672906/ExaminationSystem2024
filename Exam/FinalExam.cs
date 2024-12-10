using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
	public class FinalExam : Exam
	{
        public FinalExam(int _time ,int _numberOfQuestions):base(_time , _numberOfQuestions)
        {
            
        }
        public override void CreateListOfQuestions()
		{
			Questions = new Question[NumberOfQuestions];
			for (int i = 0; i < Questions?.Length; i++)
			{
				int Choice;
				do
				{
                    Console.WriteLine("Please Enter Type Of Quetion (1 For MCQ | 2 For True Or False)");
                }while(!(int.TryParse(Console.ReadLine(),out Choice)&& (Choice is 1 or 2)));

				Console.Clear();

				if(Choice == 1)
				{
					Questions[i] = new MCQQuestion();
					Questions[i].AddQuestion();
				}
				else
				{
					Questions[i] = new TFQuestion();
					Questions[i].AddQuestion();
				}
			}
		}

		public override void ShowExam()
		{
			foreach(var question in Questions)
			{
                // Question
                Console.WriteLine(question);

				// Choices
				for (int i = 0;i<question?.Answers?.Length;i++)
				{
					Console.WriteLine(question.Answers[i]);
                }

				int UserAnwserId;

				if(question?.GetType() == typeof(MCQQuestion))
				{
					do
					{
						Console.WriteLine("Please Enter Answer Id");
					} while (!(int.TryParse(Console.ReadLine(), out UserAnwserId) && (UserAnwserId is 1 or 2 or 3)));
				}
				else
				{
					do
					{
						Console.WriteLine("Please Enter Answer Id");
					} while (!(int.TryParse(Console.ReadLine(), out UserAnwserId) && (UserAnwserId is 1 or 2)));

				}

				question.UserAnswer.Id = UserAnwserId;
				question.UserAnswer.Text = question.Answers[UserAnwserId - 1].Text;

			}
			Console.Clear();

			int Grade = 0, TotalMarks = 0;
			for (int i = 0; i < Questions?.Length; i++)
			{
				TotalMarks += Questions[i].Mark;
				if (Questions[i].UserAnswer.Id == Questions[i].RightAnswer.Id)
				{
					Grade += Questions[i].Mark;
				}
				Console.WriteLine($"Question {i + 1} : {Questions[i].Body}");
				Console.WriteLine($"Your Answer => {Questions[i].UserAnswer.Text}");
				Console.WriteLine($"Right Answer => {Questions[i].RightAnswer.Text}");

            }
			Console.WriteLine($"Your Grade Is {Grade} from {TotalMarks}");

        }
	}
}
