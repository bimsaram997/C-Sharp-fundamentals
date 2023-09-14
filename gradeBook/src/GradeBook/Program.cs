// See https://aka.ms/new-console-template for more information


using GradeBook;

namespace GradeBoodk 
{
   
    class Program {
        public static void Main (string[]args)
        {
            IBook book = new DiskBook("Bimsara Book");
           
            //book.GradeAdded += OnGraddeAdded; //subcribe to event -= unsubscribe
            var done = false;
            
            EnterGrade(book);

            book.GetStatics();


            var stats = book.GetStatics();
            Console.WriteLine($"The Average of grades is {stats.Average:N3}");
            Console.WriteLine($"The high grades is {stats.High} and low Grade is {stats.Low}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
            Console.WriteLine($"The name of the book is {book.Name}");




        }

        private static void EnterGrade(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                   
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrades(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("****");
                }


            }

            
        }

        static void OnGraddeAdded(Object sender, EventArgs args) {
            Console.WriteLine("Grade added");
        }
    }
}