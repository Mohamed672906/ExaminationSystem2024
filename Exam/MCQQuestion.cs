using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
	public class MCQQuestion : Question
	{
		public override string Header => "MCQ Question";

        public MCQQuestion()
        {
			Answers = new Answer[3];
        }
        public override void AddQuestion()
		{
			//Header 
			Console.WriteLine(Header);

			// Question Body
			do
			{
				Console.WriteLine("Please Enter Question Body");
				Body = Console.ReadLine();
			} while (string.IsNullOrWhiteSpace(Body));
			//Mark
			int mark;
			do
			{
				Console.WriteLine("Please Enter Question Mark");
			} while (!(int.TryParse(Console.ReadLine(), out mark) && (mark > 0)));
			Mark = mark;
            // Choices
            Console.WriteLine("Choices of Question");

			for (int i = 0; i < Answers.Length; i++)
			{
				// ID
				Answers[i] = new Answer() { Id = i + 1 };

				//Text
				do
				{
					Console.WriteLine($"Please Enter Choice Number {i + 1}");
					Answers[i].Text = Console.ReadLine();
				} while (string.IsNullOrWhiteSpace(Answers[i].Text));

			}

			// Right Answer
			int rightAnswerId;
			do
			{
				Console.WriteLine("Please Enter the Right Answer Id ");
			} while (!(int.TryParse(Console.ReadLine(), out rightAnswerId) && (rightAnswerId is 1 or 2 or 3)));

			RightAnswer.Id = rightAnswerId;
			RightAnswer.Text = Answers[rightAnswerId - 1].Text;
			Console.Clear();
		}
	}
}
