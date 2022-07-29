using System; 
using System.Collections.Generic; 

namespace GradeBook
{
    class Program
    {
        static void OnGradeAdded(object sender, EventArgs e){
            Console.WriteLine("A grade was added");
        }
        static void Main(string[] args)
        {
            var book = new DiskBook("Dan's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}:");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(Book book)
        {
            
            var done = false;

            while (!done)
            {
                Console.WriteLine("Enter a grade of enter 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    done = true;
                    continue;
                }
                if (input != null)
                {
                    try
                    {
                        var grade = double.Parse(input);
                        book.AddGrade(grade);
                    }
                    catch (Exception ex) // Catching the exception means that the program won't crash when it hits the exception
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
        }
    }
}

