using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MovieRepository : IMovieRepository
    {
        private string connectionString;

        public MovieRepository()
        {
            connectionString = @"Data Source = USER-PC2; Initial Catalog=Movie_Databases; User id=sa; Password=1;";
        }
        public void AddMovie(Movie mov)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sqlInsert = "INSERT INTO Movie VALUES (NEWID(),@Tit, @y, @g, @t, @r,@key)";
                var CreatorList = connection.Query<Creator>("Select * From Creator").ToList();
                Console.WriteLine("Enter the creator's name");
                var nume = Console.ReadLine();
                connection.Execute(sqlInsert, new { Tit = mov.Title, y = mov.Year, g = mov.Genre, t = mov.Type, r = mov.Rating, key = CreatorList.Find(item => item.Name.Trim() == nume).Pk_Creator_Id });
            }
        }


        public void DeleteByIdMovie(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeleteByTitleMovie(string title)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sqlDelete = "DELETE FROM Movie WHERE Title=@t;";
                connection.Execute(sqlDelete, new { t = title });
            }

        }

        public void DeleteMovie(Movie mov)
        {
            throw new NotImplementedException();
        }

        public void EditMovie(Movie mov)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sqlUpdate = "UPDATE Movie SET Year=@y, Genre=@g, Type=@t, Rating=@r,Fk_Creator_Id=@key WHERE Title=@title";
                Console.WriteLine("Enter the creator's name");
                var nume = Console.ReadLine();
                var creators = connection.Query<Creator>("Select * From Creator;").ToList();
                mov.Fk_Creator_Id = creators.Find(item => item.Name.Trim().ToUpper() == nume.Trim().ToUpper()).Pk_Creator_Id;

                connection.Execute(sqlUpdate, new { y = mov.Year, g = mov.Genre, t = mov.Type, r = mov.Rating, key = mov.Fk_Creator_Id, title = mov.Title });
            }
        }

        public List<MovieCreator> GetAllMovies()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sqlSelect = "Select Title, Year, Genre, Type, Rating, Name From Movie INNER JOIN Creator on Fk_Creator_Id = Pk_Creator_Id;";
                return (connection.Query<MovieCreator>(sqlSelect).ToList());

            }
        }

        public Movie GetMovie(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
