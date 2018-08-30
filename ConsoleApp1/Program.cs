using System;

namespace ConsoleApp1
{
    class Program
    {
        private static MovieRepository movRepo;

        static void Main(string[] args)
        {
            movRepo = new MovieRepository();

            var opt = '1';
            while (opt != '5')
            {
                Console.Clear();
                Console.WriteLine("Select an option");
                Console.WriteLine("1.Add");
                Console.WriteLine("2.View");
                Console.WriteLine("3.Edit");
                Console.WriteLine("4.Delete");
                Console.WriteLine("5.Exit");
                opt = char.Parse(Console.ReadLine());

                switch (opt)
                {
                    case '1':
                        Add();
                        break;
                    case '2':
                        View();
                        Console.ReadKey();
                        break;
                    case '3':
                        Edit();
                        break;
                    case '4':
                        Delete();
                        break;
                    case '5':
                        Console.WriteLine("Until next time.");
                        break;
                    default:
                        Console.WriteLine("Choose a valid option");
                        break;
                }


            }
            Console.ReadLine();


        }

        private static void Delete()
        {
            Console.WriteLine("Add Title.");
            string titlu = Console.ReadLine();
            movRepo.DeleteByTitleMovie(titlu);
        }

        private static void Edit()
        {
            var newM = new MovieCreator();
            Console.WriteLine("Add Title.");
            newM.Title = Console.ReadLine();
            Console.WriteLine("Enter changed Year");
            newM.Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter changed Genre");
            newM.Genre = Console.ReadLine();
            Console.WriteLine("Enter changed Type");
            newM.Type = Console.ReadLine();
            Console.WriteLine("Please enter a rating between 1 and 5.");
            newM.Rating = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the author's name");
            newM.Name = Console.ReadLine();
            movRepo.EditMovie(newM);
        }

        private static void View()
        {
            var MovieList = movRepo.GetAllMovies();
            Console.WriteLine("Database Contains:");
            foreach (var item in MovieList)
            {
                Console.WriteLine(item.Title.Trim() + " " + item.Year + " " + item.Genre.Trim() + " " + item.Type.Trim() + " " + item.Rating + " " + item.Name);
            }
        }

        private static void Add()
        {
            MovieCreator newM = new MovieCreator();
            Console.WriteLine("Enter a new title");
            newM.Title = Console.ReadLine();
            Console.WriteLine("Enter the year");
            newM.Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the genre");
            newM.Genre = Console.ReadLine();
            Console.WriteLine("Enter the type");
            newM.Type = Console.ReadLine();
            Console.WriteLine("Enter the rating");
            newM.Rating = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter an author");
            newM.Name= Console.ReadLine();
            movRepo.AddMovie(newM);
            

        }
    }
}
