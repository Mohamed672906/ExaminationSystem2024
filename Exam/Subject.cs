using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
	public class Subject
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public Exam Exam { get; set; }
        public Subject(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }
        public void CreateExam()
        {
            int examType, time, numberOfQuestions;
            do
            {
                Console.WriteLine("Please Enter The Type of Exam (1 For Practical | 2 For Final)");
            } while (!(int.TryParse(Console.ReadLine(), out examType) && (examType is 1 or 2)));

            do
            {
                Console.WriteLine("Please Enter The Time For Exam (30 Min to 100 Max)");
            } while (!(int.TryParse(Console.ReadLine(), out time) && (time >= 30 && time <= 100)));

            do
            {
                Console.WriteLine("Please Enter Number Of Questions");
            } while (!(int.TryParse(Console.ReadLine(), out numberOfQuestions) && (numberOfQuestions > 0)));

            if(examType is 1)
            {
                Exam = new PracticalExam(time, numberOfQuestions);
            }
            else
            {
				Exam = new FinalExam(time, numberOfQuestions);
			}
            Console.Clear();
            Exam.CreateListOfQuestions();
		}
	}
}
