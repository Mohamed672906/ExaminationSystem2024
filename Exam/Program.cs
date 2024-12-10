using System.Diagnostics;

namespace Exam
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Subject Sub01 = new Subject(1, "C#");
			Sub01.CreateExam();
			Console.Clear();
			char Char;
			do
			{
				Console.WriteLine("Do you want to start Exam (Y | N)");
			} while (!(char.TryParse(Console.ReadLine(), out Char) && (Char == 'Y' || Char == 'N')));
			if(Char == 'Y')
			{
				Console.Clear();
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				Sub01.Exam.ShowExam();
				stopwatch.Stop();
                Console.WriteLine($"Time = {stopwatch.Elapsed}");
            }
            Console.WriteLine("Thank you :)");
        }
	}
}
