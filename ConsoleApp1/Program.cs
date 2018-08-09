using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(@"Data Source = USER-PC2; Initial Catalog=Movie_Databases; User id=sa; Password=1;"))
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
                    opt = char.Parse(Console.ReadLine());

                    switch (opt)
                    {
                        case '1':
                            Add(connection);
                            break;
                        case '2':
                            View(connection);
                            Console.ReadKey();
                            break;
                        case '3':
                            Edit(connection);
                            break;
                        case '4':
                            Delete(connection);
                            break;
                        case '5':
                            Console.WriteLine("Until next time.");
                            break;
                        default:
                            Console.WriteLine("Choose a valid option");
                            break;
                    }


                }


                //var MovieList = connection.Query<Movie>(sqlSelect).ToList();
                ////var orderDetail = connection.QueryFirstOrDefault<OrderDetail>(sqlOrderDetail, new { OrderDetailID = 1 });
                ////var affectedRows = connection.Execute(sqlCustomerInsert, new { CustomerName = "Mark" });
                Console.ReadLine();
                ////Console.WriteLine(affectedRows);

                ////FiddleHelper.WriteTable(MovieList);
                ////FiddleHelper.WriteTable(new List<OrderDetail>() { orderDetail });
            }
        }

        private static void Delete(SqlConnection x)
        {

            string sqlDelete = "DELETE FROM Movie WHERE Title=@t;";
            string sqlSelect = "Select * From Movie;";
            var MovieList = x.Query<Movie>(sqlSelect).ToList();
            for (int i = 0; i < MovieList.Count; i++)
            {

                Console.WriteLine(MovieList[i].Title.Trim());
            }
            Console.WriteLine("Select series title to delete .");
            string titlu = Console.ReadLine();
            var myItem = MovieList.Find(item => item.Title.Trim() == titlu);
            x.Execute(sqlDelete, new { t = titlu });
            var wqs = MovieList.Find(item => item.Fk_Creator_Id == myItem.Fk_Creator_Id);
            if (MovieList.Find(item => item.Fk_Creator_Id == myItem.Fk_Creator_Id) == null)
            {
                x.Execute("DELETE FROM Movie WHERE Title where PK_Creator_Id=@t", new { t = myItem.Fk_Creator_Id });
            }
        }

        private static void Edit(SqlConnection x)
        {
            string sqlUpdate = "UPDATE Movie SET Year=@y, Genre=@g, Type=@t, Rating=@r,Fk_Creator_Id=@key WHERE Title=@title";
            Console.WriteLine("Titles:");
            string sqlSelect = "Select Title From Movie";
            var MovieList = x.Query<Movie>(sqlSelect).ToList();
            var CreatorList = x.Query<Creator>("Select * From Creator").ToList();
            foreach (var item in MovieList)
            {
                Console.WriteLine(item.Title);
            }
            Console.WriteLine("Select series title from above to change.");
            var tit = Console.ReadLine();
            Movie newM = new Movie();
            Console.WriteLine("Enter changed Year");
            newM.Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter changed Genre");
            newM.Genre = Console.ReadLine();
            Console.WriteLine("Enter changed Type");
            newM.Type = Console.ReadLine();
            Console.WriteLine("Please enter a rating between 1 and 5.");
            newM.Rating = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the creator's name");
            var nume = Console.ReadLine();
            //Console.WriteLine("Is it ok ?Y/N");
            //Console.WriteLine(newM.Title.Trim() + " " + newM.Year + " " + newM.Genre.Trim() + " " + newM.Type.Trim() + " " + newM.Rating + " " + newM.Fk_Creator_Id);
            //if (Console.ReadKey().Key == ConsoleKey.N)
            //{
            //    return;
            //}
            x.Execute(sqlUpdate, new { y = newM.Year, g = newM.Genre, t = newM.Type, r = newM.Rating, key = CreatorList.Find(item => item.Name.Trim() == nume).Pk_Creator_Id, title = tit });

        }

        private static void View(SqlConnection x)
        {
            string sqlSelect = "Select Title, Year, Genre, Type, Rating, Name From Movie INNER JOIN Creator on Fk_Creator_Id = Pk_Creator_Id;";
            var MovieList = x.Query<MovieCreator>(sqlSelect).ToList();
            for (int i = 0; i < MovieList.Count; i++)
            {

                Console.WriteLine(MovieList[i].Title.Trim() + " " + MovieList[i].Year + " " + MovieList[i].Genre.Trim() + " " + MovieList[i].Type.Trim() + " " + MovieList[i].Rating + " " + MovieList[i].Name);
            }
        }

        private static void Add(SqlConnection x)
        {


            string sqlInsert = "INSERT INTO Movie VALUES (NEWID(),@Tit, @y, @g, @t, @r,@key)";
            var CreatorList = x.Query<Creator>("Select * From Creator").ToList();
            Movie newM = new Movie();
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
            Console.WriteLine("Enter the creator's name");
            var nume = Console.ReadLine();
            x.Execute(sqlInsert, new { Tit = newM.Title, y = newM.Year, g = newM.Genre, t = newM.Type, r = newM.Rating, key = CreatorList.Find(item => item.Name.Trim() == nume).Pk_Creator_Id });


        }
    }
}
