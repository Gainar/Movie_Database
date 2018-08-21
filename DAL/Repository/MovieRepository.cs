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
            //connectionString = @"Data Source = USER-PC2; Initial Catalog=Movie_Databases; User id=sa; Password=1;";
            connectionString = @"Data Source= den1.mssql5.gear.host; Initial Catalog=moviedata;User id=moviedata;Password=Dc476_-oMx12;";
        }
        public void AddMovie(MovieCreator mov)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sqlInsert = "INSERT INTO Movie VALUES (NEWID(),@Tit, @y, @g, @t, @r,@key)";
                var CreatorList = connection.Query<Creator>("Select * From Creator").ToList();
                connection.Execute(sqlInsert, new { Tit = mov.Title, y = mov.Year, g = mov.Genre, t = mov.Type, r = mov.Rating, key = CreatorList.Find(item => item.Name.Trim() == mov.Name).Pk_Creator_Id });
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

        public MovieCreator GetMovie(string tit)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sqlSelect = "Select Title, Year, Genre, Type, Rating, Name From Movie INNER JOIN Creator on Fk_Creator_Id = Pk_Creator_Id Where Title=@title ;";
                var mov = connection.Query<MovieCreator>(sqlSelect, new { title = tit }).ToList();
                return mov[0];

            }
        }

        public List<MovieCreator> Querry(string param, string val)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "Select Title, Year, Genre, Type, Rating, Name From Movie INNER JOIN Creator on Fk_Creator_Id = Pk_Creator_Id Where " + param + "=" + val + ";";
                var mov = connection.Query<MovieCreator>(sql).ToList();
                return mov;
            }
        }

        public List<MovieCreator> Querry(string param)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var s = new string[2] { "ASC", "DESC" };
                string sql;
                if (param.ToUpper() == "TITLE")
                    sql = "Select Title, Year, Genre, Type, Rating, Name From Movie INNER JOIN Creator on Fk_Creator_Id = Pk_Creator_Id Order BY " + param + " ASC";
                else
                    sql = "Select Title, Year, Genre, Type, Rating, Name From Movie INNER JOIN Creator on Fk_Creator_Id = Pk_Creator_Id Order BY " + param + " DESC, Title ASC";
                var mov = connection.Query<MovieCreator>(sql).ToList();
                return mov;
            }
        }
    }
}
