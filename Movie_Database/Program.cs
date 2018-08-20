//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Dapper;
//using System.Data.SqlClient;
//using Dapper;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;

//namespace Movie_Database
//{
//    // @nuget: Dapper
//    // @nuget: Microsoft.SqlServer.Compact

//    public class Program
//    {
//        public class Customer
//        {
//            public int CustomerID { get; set; }
//            public string CustomerName { get; set; }
//            public string ContactName { get; set; }
//            public string Address { get; set; }
//            public string City { get; set; }
//            public string PostalCode { get; set; }
//            public string Country { get; set; }
//        }

//        public class OrderDetail
//        {
//            public int OrderDetailID { get; set; }
//            public int OrderID { get; set; }
//            public int ProductID { get; set; }
//            public int Quantity { get; set; }
//        }


//        public static void Main()
//        {
//            string sqlOrderDetails = "SELECT TOP 5 * FROM OrderDetails;";
//            string sqlOrderDetail = "SELECT * FROM OrderDetails WHERE OrderDetailID = @OrderDetailID;";
//            string sqlCustomerInsert = "INSERT INTO Customers (CustomerName) Values (@CustomerName);";



//            using (var connection = new SqlConnection("Data Source=SqlCe_W3Schools.sdf"))
//            {
//                var orderDetails = connection.Query<OrderDetail>(sqlOrderDetails).ToList();
//                var orderDetail = connection.QueryFirstOrDefault<OrderDetail>(sqlOrderDetail, new { OrderDetailID = 1 });
//                var affectedRows = connection.Execute(sqlCustomerInsert, new { CustomerName = "Mark" });

//                Console.WriteLine(orderDetails.Count);
//                Console.WriteLine(affectedRows);

//                //FiddleHelper.WriteTable(orderDetails);
//                //FiddleHelper.WriteTable(new List<OrderDetail>() { orderDetail });
//            }
//        }

//    }
//    //    class Program
//    //    {
//    //        static void Main(string[] args)
//    //        {
//    //            List<S_M> Database = new List<S_M>();
//    //            char opt = '1';
//    //            while (opt != '0')
//    //            {
//    //                Console.Clear();
//    //                Console.WriteLine("Select action.");
//    //                Console.WriteLine("1.Add a new movie.");
//    //                Console.WriteLine("2.See the collection of movies.");
//    //                Console.WriteLine("3.Edit  movies.");
//    //                Console.WriteLine("4.Remove a specific movie.");
//    //                Console.WriteLine("0.Exit");
//    //                opt = char.Parse(Console.ReadLine());
//    //                switch (opt)
//    //                {
//    //                    case '1':
//    //                        S_M dat = new S_M();
//    //                        Console.WriteLine("Give the following informations about the Series/Movie");
//    //                        Console.WriteLine("Title:");
//    //                        dat.Title = Console.ReadLine();
//    //                        Console.WriteLine("Year:");
//    //                        dat.Year = int.Parse(Console.ReadLine());
//    //                        Console.WriteLine("Genre:");
//    //                        dat.Genre = Console.ReadLine();
//    //                        Console.WriteLine("Type:");
//    //                        dat.Type = Console.ReadLine();
//    //                        Console.WriteLine("Your Rating:");
//    //                        dat.Rating = byte.Parse(Console.ReadLine());
//    //                        Console.WriteLine("Creator:");
//    //                        dat.Creator = Console.ReadLine();
//    //                        Database.Add(dat);

//    //                        break;
//    //                    case '2':
//    //                        Console.Clear();
//    //                        SeeAll(Database);
//    //                        Console.ReadLine();
//    //                        break;
//    //                    case '3':
//    //                        Console.Clear();
//    //                        Console.WriteLine("Choose a Title to modify it's content:");
//    //                        foreach (var item in Database)
//    //                        {
//    //                            Console.WriteLine(item.Title);
//    //                        }
//    //                        string title;
//    //                        title = Console.ReadLine();
//    //                        foreach (var item in Database)
//    //                            if (item.Title == title)
//    //                            {
//    //                                Console.WriteLine("Year:");
//    //                                item.Year = int.Parse(Console.ReadLine());
//    //                                Console.WriteLine("Genre:");
//    //                                item.Genre = Console.ReadLine();
//    //                                Console.WriteLine("Type:");
//    //                                item.Type = Console.ReadLine();
//    //                                Console.WriteLine("Your Rating:");
//    //                                item.Rating = byte.Parse(Console.ReadLine());
//    //                                Console.WriteLine("Creator:");
//    //                                item.Creator = Console.ReadLine();

//    //                            }
//    //                        {

//    //                        }
//    //                        break;
//    //                    case '4':
//    //                        Console.Clear();
//    //                        Console.WriteLine("Choose a Title to delete:");
//    //                        foreach (var item in Database)
//    //                        {
//    //                            Console.WriteLine(item.Title);
//    //                        }
//    //                        title = Console.ReadLine();
//    //                        foreach (var item in Database)
//    //                            if (item.Title == title)
//    //                            {
//    //                                Database.Remove(item);
//    //                                break;
//    //                            }

//    //                        break;
//    //                    case '0':
//    //                        break;
//    //                    default:
//    //                        Console.WriteLine("Choose a correct option.");

//    //                        break;
//    //                }

//    //            }
//    //            void SeeAll(List<S_M> da)
//    //            {
//    //                foreach (var item in Database)
//    //                {
//    //                    Console.WriteLine(item.Title + " is a " + item.Type + " and a " + item.Genre + ", it was released in the year of  " + item.Year + " by the creator " + item.Creator + ", and i give it a " + item.Rating);
//    //                    Console.WriteLine();


//    //                }
//    //            }
//    //        }
//    //    }
//}