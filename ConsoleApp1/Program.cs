using System;
using Movie.Core.Models;
using Movie.Proxy.Proxy;


namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
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
                opt = char.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

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
            var desktopRepo= new Desktop();
            Console.WriteLine("Add Title.");
            string tit = Console.ReadLine();
            desktopRepo.Delete(tit);
        }

        private static void Edit()
        {
            var desktopRepo = new Desktop();
            var newM = new MovieCreator();
            Console.WriteLine("Add Title.");
            newM.Title = Console.ReadLine();
            Console.WriteLine("Enter changed Year");
            newM.Year = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Enter a valid Year"));
            Console.WriteLine("Enter changed Genre");
            newM.Genre = Console.ReadLine();
            Console.WriteLine("Enter changed Type");
            newM.Type = Console.ReadLine();
            Console.WriteLine("Please enter a rating between 1 and 5.");
            newM.Rating = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Enter a valid Rating(1-5)"));
            Console.WriteLine("Please enter the author's name");
            newM.Name = Console.ReadLine();
            desktopRepo.Edit(newM);
        }

        private static async void View()
        {
            var desktopRepo = new Desktop();
            var movieList = await desktopRepo.View();
            Console.WriteLine("Database Contains:");
            foreach (var item in movieList)
            {
                Console.WriteLine(item.Title.Trim() + " " + item.Year + " " + item.Genre.Trim() + " " + item.Type.Trim() + " " + item.Rating + " " + item.Name);
            }
        }

        private static void Add()
        {
            var desktopRepo = new Desktop();
            var newM = new MovieCreator();
            Console.WriteLine("Enter a new title");
            newM.Title = Console.ReadLine();
            Console.WriteLine("Enter the year");
            newM.Year = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Enter a valid Year"));
            Console.WriteLine("Enter the genre");
            newM.Genre = Console.ReadLine();
            Console.WriteLine("Enter the type");
            newM.Type = Console.ReadLine();
            Console.WriteLine("Enter the rating");
            newM.Rating = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Enter a valid Rating(1-5)"));
            Console.WriteLine("Enter an author");
            newM.Name = Console.ReadLine();
            desktopRepo.Add(newM);


        }
    }
}
